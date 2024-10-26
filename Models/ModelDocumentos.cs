using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Models
{
    public class ModelDocumentos : IDocumento
    {
        private int _documento_id;
        private string _documento_nombre;
        private int _documento_tipo;

        public int DocumentoID { get => _documento_id; set => _documento_id = value; }
        public string DocumentoNombre { get => _documento_nombre; set => _documento_nombre = value; }
        public int DocumentoTipo { get => _documento_tipo; set => _documento_tipo = value; }
                
    }
}
