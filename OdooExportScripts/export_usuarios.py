import pyodbc
import os
import bcrypt
from lxml import etree
import sys
sys.stdout.reconfigure(encoding='utf-8')


# 🔹 Configuración de la base de datos y la exportación
server = r'INGRID-PC'  
database = 'HotelSOL'
output_dir = r'C:\Users\Administrator\OneDrive\Escritorio\desArrollados\SQLEXPRESS'
output_file = os.path.join(output_dir, 'usuarios.xml')

# 🔹 Crear carpeta si no existe
os.makedirs(output_dir, exist_ok=True)

# 🔹 Conexión a SQL Server
conn_str = (
    f"DRIVER={{ODBC Driver 17 for SQL Server}};"
    f"SERVER={server};"
    f"DATABASE={database};"
    f"Trusted_Connection=yes;"
    f"TrustServerCertificate=yes;"
)

# 🔹 Función para encriptar contraseñas antes de exportarlas
def encriptar_contraseña(contraseña):
    if contraseña:
        salt = bcrypt.gensalt()
        return bcrypt.hashpw(contraseña.encode('utf-8'), salt).decode('utf-8')
    return ""

try:
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    # 🔹 Extraer datos de usuarios asegurando los nombres de columnas correctos
    cursor.execute("SELECT Id, nombre, email, rol, ClienteID, Contraseña FROM Usuarios")

    root = etree.Element("Usuarios")  # ✅ Estructura XML corregida

    for row in cursor.fetchall():
        usuario_elem = etree.SubElement(root, "Usuario")

        # 🔹 Verificación segura para evitar valores None
        usuario_id = str(row.Id) if row.Id is not None else "0"
        cliente_id = str(row.ClienteID) if row.ClienteID is not None else "0"

        # 🔹 Agregar datos al XML
        etree.SubElement(usuario_elem, "Id").text = usuario_id
        etree.SubElement(usuario_elem, "Nombre").text = row.nombre or ""
        etree.SubElement(usuario_elem, "Email").text = row.email or ""
        etree.SubElement(usuario_elem, "Rol").text = row.rol or "Cliente"
        etree.SubElement(usuario_elem, "ClienteID").text = cliente_id

        # ✅ Encriptar contraseña antes de exportarla
        contraseña_encriptada = encriptar_contraseña(row.Contraseña)
        etree.SubElement(usuario_elem, "Contraseña").text = contraseña_encriptada

    # 🔹 Guardar archivo XML correctamente
    tree = etree.ElementTree(root)
    tree.write(output_file, pretty_print=True, xml_declaration=True, encoding='utf-8')

    print(f"✅ Archivo de usuarios exportado correctamente: {output_file}")

except Exception as e:
    print(f"❌ Error durante la exportación: {e}")
