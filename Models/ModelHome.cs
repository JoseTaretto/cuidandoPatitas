using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelHome : IMensaje
    {
        private string _mensaje_nombre;
        private string _mensaje_telefono;
        private string _mensaje_mail;
        private string _mensaje_mensaje;

        public string MensajeNombre { get => _mensaje_nombre; set => _mensaje_nombre = value; }
        public string MensajeTelefono { get => _mensaje_telefono; set => _mensaje_telefono = value; }
        public string MensajeMail { get => _mensaje_mail; set => _mensaje_mail = value; }
        public string MensajeMensaje { get => _mensaje_mensaje; set => _mensaje_mensaje = value; }


        // Propidedades de navegacion
        public List<ModelAnimales> ListaRescatados;
        public List<ModelAnimales> ListaAdoptados;
    }
}
