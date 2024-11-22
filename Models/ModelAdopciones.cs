using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelAdopciones : IAnimal, IUsuario
    {
        // Atributos de la tabla
        private int _adopciones_id;
        private int _usuario_id;
        private int _animal_id;
        private int _adopcion_estado;
        private string _adopcion_observaciones;
        private DateTime _fecha_alta;
        private int _user_alta;
        private DateTime _fecha_modificacion;
        private int _user_modificacion;
        private DateTime _fecha_baja;
        private int _user_baja;

        // Atributos de interfaz
        private string _animal_nombre;
        private string _usuario_user_name;

        // Propiedades de la tabla

        public int AdopcionesId { get => _adopciones_id; set => _adopciones_id = value; }
        public int UsuarioId { get => _usuario_id; set => _usuario_id = value; }
        public int AnimalId { get => _animal_id; set => _animal_id = value; }
        public int AdopcionEstadoId { get => _adopcion_estado; set => _adopcion_estado = value; }
        public string AdopcionObservaciones { get => _adopcion_observaciones; set => _adopcion_observaciones = value; }
        public DateTime FechaAlta { get => _fecha_alta; set => _fecha_alta = value; }
        public int UserAlta { get => _user_alta; set => _user_alta = value; }
        public DateTime FecheModificacion { get => _fecha_modificacion; set => _fecha_modificacion = value; }
        public int UserModificacion { get => _user_modificacion; set => _user_modificacion = value; }
        public DateTime FechaBaja { get => _fecha_baja; set => _fecha_baja = value; }
        public int UserBaja { get => _user_baja; set => _user_baja = value; }

        // Propiedades de Interfaz
        public string AnimalNombre { get => _animal_nombre; set => _animal_nombre = value; }
        public string UsuarioUserName { get => _usuario_user_name; set => _usuario_user_name = value; }
    }
}
