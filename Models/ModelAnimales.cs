using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
   public class ModelAnimales : IDocumento, IEspecie, IAnimalEstado, IAnimal
    {   
        // ESTRUCTURA TABLA
        private int _animal_id;
        private int _especie_id;        
        private int _raza_id;
        private string _animal_nombre;
        private char _animal_sexo;
        private int _animal_edad;
        private DateTime _animal_fecha_nacimiento;
        private int _documento_id;        
        private string _animal_documento;
        private decimal _animal_peso;
        private int _animal_castrado;
        private int _animal_estado_id;
        private string _animal_descripcion;
        private DateTime _fecha_alta;
        private int _user_alta;
        private DateTime _fecha_modificacion;
        private int _user_modificacion;
        private DateTime _fecha_baja;
        private int _user_baja;
        private int _adoptado;
        private string _imagen;

        // INTERFACES
        private string _especie_nombre;
        private string _documento_nombre;
        private string _animal_estado_nombre;

        // PROPIEDADES PUBLICAS DE TABLAS
        public int AnimalId { get => _animal_id; set => _animal_id = value; }
        public int EspecieId { get => _especie_id; set => _especie_id = value; }        
        public int RazaId { get => _raza_id; set => _raza_id = value; }
        public string AnimalNombre { get => _animal_nombre; set => _animal_nombre = value; }
        public char AnimalSexo { get => _animal_sexo; set => _animal_sexo = value; }
        public int AnimalEdad { get => _animal_edad; set => _animal_edad = value; }
        public DateTime AnimalFechaNacimiento { get => _animal_fecha_nacimiento; set => _animal_fecha_nacimiento = value; }
        public int DocumentoID { get => _documento_id; set => _documento_id = value; }        
        public string AnimalDocumento{ get => _animal_documento; set => _animal_documento = value; }
        public decimal AnimalPeso { get => _animal_peso; set => _animal_peso = value; }
        public int AnimalCastrado { get => _animal_castrado; set => _animal_castrado = value; }
        public int AnimalEstadoId { get => _animal_estado_id; set => _animal_estado_id = value; }
        public string AnimalDescripcion { get => _animal_descripcion; set => _animal_descripcion = value; }
        public DateTime FechaAlta { get => _fecha_alta; set => _fecha_alta = value; }
        public int UserAlta { get => _user_alta; set => _user_alta = value; }
        public DateTime FechaModificacion { get => _fecha_modificacion; set => _fecha_modificacion = value; }
        public int UserModificacion { get => _user_modificacion; set => _user_modificacion = value; }
        public DateTime FechaBaja { get => _fecha_baja; set => _fecha_baja = value; }
        public int UserBaja { get => _user_baja; set => _user_baja = value; }
        public int Adoptado { get => _adoptado; set => _adoptado = value; }
        public string imagen { get => _imagen; set => _imagen = value; }

        // PROPIEDADES PUBLICAS DE INTERFACES
        public string EspecieNombre { get => _especie_nombre; set => _especie_nombre = value; }
        public string DocumentoNombre { get => _documento_nombre; set => _documento_nombre = value; }
        public string AnimalEstadoNombre { get => _animal_estado_nombre; set => _animal_estado_nombre = value; }
    }
}


