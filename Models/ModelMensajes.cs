using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelMensajes : IMensaje
    {
        private int _mensaje_id;
        private string _mensaje_nombre;
        private string _mensaje_telefono;
        private string _mensaje_mail;
        private string _mensaje_mensaje;
        private DateTime _mensaje_fecha;
        private int _mensaje_visto;

        public int MensajeId { get => _mensaje_id; set => _mensaje_id = value; }
        public string MensajeNombre { get => _mensaje_nombre; set => _mensaje_nombre = value; }
        public string MensajeTelefono { get => _mensaje_telefono; set => _mensaje_telefono = value; }
        public string MensajeMail { get => _mensaje_mail; set => _mensaje_mail = value; }
        public string MensajeMensaje { get => _mensaje_mensaje; set => _mensaje_mensaje = value; }
        public DateTime MensajeFecha { get => _mensaje_fecha; set => _mensaje_fecha = value; } 
        public int MensajeVisto { get => _mensaje_visto; set => _mensaje_visto = value; }

    }
}
