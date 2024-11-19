using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelAnimalEstado : IAnimalEstado
    {
        private int _animal_estado_id;
        private string _animal_estado_nombre;

        public int AnimalEstadoId { get => _animal_estado_id; set => _animal_estado_id = value; }
        public string AnimalEstadoNombre { get => _animal_estado_nombre; set => _animal_estado_nombre = value; }

    }
}
