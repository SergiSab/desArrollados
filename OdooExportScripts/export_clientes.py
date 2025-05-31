import pyodbc
import os
from lxml import etree

# Configuración
server = r'INGRID-PC'  
database = 'HotelSOL'
output_dir = r'C:\Users\Administrator\OneDrive\Escritorio\desArrollados\SQLEXPRESS'
output_file = os.path.join(output_dir, 'clientes.xml')

# Crear carpeta si no existe
os.makedirs(output_dir, exist_ok=True)

# Conexión a SQL Server
conn_str = (
    f"DRIVER={{ODBC Driver 17 for SQL Server}};"
    f"SERVER={server};"
    f"DATABASE={database};"
    f"Trusted_Connection=yes;"
    f"TrustServerCertificate=yes;"
)

try:
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    cursor.execute("""
        SELECT ClienteId, dni, nombre, apellido, direccion, email, telefono, vip, UsuarioId
        FROM Clientes
    """)

    # Crear XML
    root = etree.Element("Clientes")

    for row in cursor.fetchall():
        cliente_elem = etree.SubElement(root, "Cliente")

        # Asegurar que ClienteId y UsuarioId sean números enteros válidos
        cliente_id = str(getattr(row, "ClienteId", 0)) if row.ClienteId is not None else "0"
        usuario_id = str(getattr(row, "UsuarioId", 0)) if row.UsuarioId is not None else "0"

        etree.SubElement(cliente_elem, "ClienteId").text = cliente_id
        etree.SubElement(cliente_elem, "UsuarioId").text = usuario_id

        # Manejar datos evitando `None`
        etree.SubElement(cliente_elem, "DNI").text = getattr(row, "dni", "") or ""
        etree.SubElement(cliente_elem, "Nombre").text = getattr(row, "nombre", "") or ""
        etree.SubElement(cliente_elem, "Apellido").text = getattr(row, "apellido", "") or ""
        etree.SubElement(cliente_elem, "Direccion").text = getattr(row, "direccion", "") or ""
        etree.SubElement(cliente_elem, "Email").text = getattr(row, "email", "") or ""
        etree.SubElement(cliente_elem, "Telefono").text = getattr(row, "telefono", "") or ""
        etree.SubElement(cliente_elem, "VIP").text = "true" if getattr(row, "vip", False) else "false"

    # Guardar archivo XML con formato bonito
    tree = etree.ElementTree(root)
    tree.write(output_file, pretty_print=True, xml_declaration=True, encoding='utf-8')

    print(f"Archivo exportado correctamente: {output_file}")

except Exception as e:
    print(f"Error durante la exportación: {e}")
