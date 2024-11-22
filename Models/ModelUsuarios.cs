
using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelUsuarios : IUsuario
    {
        // Atributos privados
        private int _usuario_id;
        private string _usuario_user_name;
        private string _usuario_password;
        private string _usuario_rol;
        private string _usuario_nombre;
        private string _usuario_apellido;
        private DateTime _usuario_fecha_nacimiento;
        private int _documento_id;
        private string _documento_nombre;
        private string _usuario_documento;
        private string _usuario_email;
        private string _usuario_telefono_1;
        private string _usuario_telefono_2;
        private string _usuario_direccion;
        private int _localidad_id;
        private int _provincia_id;
        private int _usuario_activo;
        private DateTime _fecha_alta;
        private int _user_alta;
        private DateTime _fecha_modificacion;
        private int _user_modificacion;
        private DateTime _fecha_baja;
        private int _user_baja;

        // Propiedades Publicas
        public int UsuarioId { get => _usuario_id; set => _usuario_id = value; }
        public string UsuarioUserName { get => _usuario_user_name; set => _usuario_user_name = value; }
        public string UsuarioPassword { get => _usuario_password; set => _usuario_password = value; }
        public string UsuarioRol { get => _usuario_rol; set => _usuario_rol = value; }
        public string UsuarioNombre { get => _usuario_nombre; set => _usuario_nombre = value; }
        public string UsuarioApellido { get => _usuario_apellido; set => _usuario_apellido = value; }
        public DateTime UsuarioFechaNacimiento { get => _usuario_fecha_nacimiento; set => _usuario_fecha_nacimiento = value; }
        public int DocumentoID { get => _documento_id; set => _documento_id = value; }
        public string DocumentoNombre { get => _documento_nombre; set => _documento_nombre = value; }
        public string UsuarioDocumento { get => _usuario_documento; set => _usuario_documento = value; }
        public string UsuarioEmail { get => _usuario_email; set => _usuario_email = value; }
        public string UsuarioTelefono1 { get => _usuario_telefono_1; set => _usuario_telefono_1 = value; }
        public string UsuarioTelefono2 { get => _usuario_telefono_2; set => _usuario_telefono_2 = value; }
        public string UsuarioDireccion { get => _usuario_direccion; set => _usuario_direccion = value; }
        public int LocalidadId { get => _localidad_id; set => _localidad_id = value; }
        public int ProvinciaId { get => _provincia_id; set => _provincia_id = value; }
        public int UsuarioActivo { get => _usuario_activo; set => _usuario_activo = value; }
        public DateTime FechaAlta { get => _fecha_alta; set => _fecha_alta = value; }
        public int UserAlta { get => _user_alta; set => _user_alta = value; }
        public DateTime FechaModificacion { get => _fecha_modificacion; set => _fecha_modificacion = value; }
        public int UserModificacion { get => _user_modificacion; set => _user_modificacion = value; }
        public DateTime FechaBaja { get => _fecha_baja; set => _fecha_baja = value; }
        public int UserBaja { get => _user_baja; set => _user_baja = value; }
    }
}
