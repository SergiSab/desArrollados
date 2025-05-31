import xmlrpc.client
import bcrypt  
from lxml import etree

# Conectar con Odoo
ODOO_URL = "http://localhost:8069"
DB = "HotelSOL"  
USERNAME = "idiazris@uoc.edu"
PASSWORD = "1234"

common = xmlrpc.client.ServerProxy(f"{ODOO_URL}/xmlrpc/2/common")
uid = common.authenticate(DB, USERNAME, PASSWORD, {})
print(f"Conexión establecida con Odoo. UID obtenido: {uid}")
 
if not uid:
    print("Error en autenticación con Odoo")
    exit()

models = xmlrpc.client.ServerProxy(f"{ODOO_URL}/xmlrpc/2/object")

# Leer el XML generado
xml_file = r"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\SQLEXPRESS\usuarios.xml"
tree = etree.parse(xml_file)
root = tree.getroot()

# Mapeo de nombres de rol en XML a valores permitidos en Odoo
rol_mapping = {
    "Administrador": "admin",
    "Recepcionista": "recepcionista",
    "Cliente": "cliente",
    "Encargado": "encargado",
    "Contable": "contable",
    "Personal Limpieza": "personal_limpieza",
    "Personal Restauración": "personal_restauracion"
}

# 🔹 Función para encriptar contraseñas antes de enviarlas a Odoo
def encriptar_contraseña(contraseña):
    if contraseña:
        salt = bcrypt.gensalt()
        return bcrypt.hashpw(contraseña.encode('utf-8'), salt).decode('utf-8')
    return ""  # Si la contraseña está vacía

usuarios = []
for usuario in root.findall("Usuario"):
    try:
        usuario_id_sql = int(usuario.find("Id").text) if usuario.find("Id") is not None and usuario.find("Id").text else 0
        nombre = usuario.find("Nombre").text if usuario.find("Nombre") is not None else "Sin nombre"
        email = usuario.find("Email").text if usuario.find("Email") is not None else ""  
        rol_xml = usuario.find("Rol").text if usuario.find("Rol") is not None else "Cliente"
        rol_odoo = rol_mapping.get(rol_xml, "cliente")

        # ✅ ClienteID puede ser opcional
        cliente_id = int(usuario.find("ClienteID").text) if usuario.find("ClienteID") is not None and usuario.find("ClienteID").text else 0

        # 🔒 Encriptar la contraseña antes de enviarla a Odoo
        contraseña = usuario.find("Contraseña").text if usuario.find("Contraseña") is not None else ""
        contraseña_encriptada = encriptar_contraseña(contraseña)

        # ✅ Verificar si el usuario ya existe en Odoo antes de crearlo
        usuario_existente = models.execute_kw(DB, uid, PASSWORD, 'hotel.usuario', 'search', [[('usuario_id_sql', '=', usuario_id_sql)]])
        
        if usuario_existente:
            # 🔹 Si el usuario ya existe, actualizar los datos en lugar de crearlo
            models.execute_kw(DB, uid, PASSWORD, 'hotel.usuario', 'write', [usuario_existente, {
                'nombre': nombre,
                'email': email,
                'rol': rol_odoo,
                'clienteId': cliente_id,  
                'contraseña': contraseña_encriptada
            }])
            print(f"Usuario actualizado en Odoo con ID: {usuario_existente[0]} (SQL ID: {usuario_id_sql})")
        else:
            # 🔹 Si el usuario no existe, crearlo
            usuario_odoo_id = models.execute_kw(DB, uid, PASSWORD, 'hotel.usuario', 'create', [{
                'usuario_id_sql': usuario_id_sql,
                'nombre': nombre,
                'email': email,
                'rol': rol_odoo,
                'clienteId': cliente_id,  
                'contraseña': contraseña_encriptada
            }])
            print(f"Usuario creado en Odoo con ID: {usuario_odoo_id} (SQL ID: {usuario_id_sql})")
            
    except Exception as e:
        print(f"Error procesando usuario: {e}")
