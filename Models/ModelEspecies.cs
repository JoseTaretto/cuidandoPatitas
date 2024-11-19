using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelEspecies : IEspecie
    {
        private int _especie_id;
        private string _especie_nombre;
        private int _especie_activo;

        public int EspecieId { get => _especie_id; set => _especie_id = value; }
        public string EspecieNombre { get => _especie_nombre; set => _especie_nombre = value; }
        public int EspecieActivo { get => _especie_activo; set => _especie_activo = value; }
    }
}
