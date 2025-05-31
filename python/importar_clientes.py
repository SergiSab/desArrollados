import xmlrpc.client
from lxml import etree

# Conectar con Odoo
ODOO_URL = "http://localhost:8069"
DB = "HotelSOL"
USERNAME = "idiazris@uoc.edu"
PASSWORD = "1234"

common = xmlrpc.client.ServerProxy(f"{ODOO_URL}/xmlrpc/2/common")
uid = common.authenticate(DB, USERNAME, PASSWORD, {})

if not uid:
    print("Error en autenticación con Odoo")
    exit()

models = xmlrpc.client.ServerProxy(f"{ODOO_URL}/xmlrpc/2/object")

# Leer el XML generado
xml_file = r"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\SQLEXPRESS\clientes.xml"
tree = etree.parse(xml_file)
root = tree.getroot()

# Obtener clientes existentes en Odoo para evitar duplicados
clientes_existentes = models.execute_kw(DB, uid, PASSWORD, 'hotel.cliente', 'search_read', [[]], {'fields': ['cliente_id']})
clientes_validos = {cliente['cliente_id'] for cliente in clientes_existentes}

clientes = []
for cliente in root.findall("Cliente"):
    try:
        cliente_id = int(cliente.find("ClienteId").text)

        # Si el cliente ya existe en Odoo, no lo duplicamos
        if cliente_id in clientes_validos:
            print(f"Cliente ID {cliente_id} ya existe en Odoo, se omitirá.")
            continue

        usuario_id_sql = int(cliente.find("UsuarioId").text) if cliente.find("UsuarioId") is not None else 0
        usuario_odoo = models.execute_kw(DB, uid, PASSWORD, 'hotel.usuario', 'search', [[('usuario_id_sql', '=', usuario_id_sql)]])
        usuario_odoo_id = usuario_odoo[0] if usuario_odoo else False  # Si existe, asignarlo
        clientes.append({
            'cliente_id': cliente_id,
            'dni': cliente.find("DNI").text or "",
            'nombre': cliente.find("Nombre").text or "",
            'apellido': cliente.find("Apellido").text or "",
            'direccion': cliente.find("Direccion").text or "",
            'email': cliente.find("Email").text or "",
            'telefono': cliente.find("Telefono").text or "",
            'vip': cliente.find("VIP").text == "true",
            'usuario_id_sql': int(cliente.find("UsuarioId").text) if cliente.find("UsuarioId") is not None else 0,
            'usuario_id_odoo': usuario_odoo_id  # 🔹 Se enlaza con el usuario en Odoo
        })



    except Exception as e:
        print(f"Error procesando cliente: {e}")

print(f"Clientes a importar: {len(clientes)}")


for cliente in clientes:
    try:
        # Verificamos si el cliente ya está en Odoo
        cliente_existente = models.execute_kw(DB, uid, PASSWORD, 'hotel.cliente', 'search', [[('cliente_id', '=', cliente['cliente_id'])]])

        if cliente_existente:
            # ✅ Si el cliente ya existe, actualizamos los datos en lugar de crear uno nuevo
            models.execute_kw(DB, uid, PASSWORD, 'hotel.cliente', 'write', [cliente_existente, cliente])
            print(f"Cliente actualizado en Odoo con ID: {cliente_existente[0]} (SQL ID: {cliente['cliente_id']})")
        else:
            # ✅ Si el cliente NO existe, se crea uno nuevo
            cliente_odoo_id = models.execute_kw(DB, uid, PASSWORD, 'hotel.cliente', 'create', [cliente])
            print(f"Cliente creado en Odoo con ID: {cliente_odoo_id} (SQL ID: {cliente['cliente_id']})")
    except Exception as e:
        print(f"Error al crear/actualizar cliente en Odoo: {e}")
