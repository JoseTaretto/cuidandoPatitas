namespace AppCuidandoPatitas.Interface
{
    public interface IDocumento
    {
        int DocumentoID { get; set; }
        string DocumentoNombre { get; set; }

        public enum TipoDocumento
        {
            DocumentoHumano = 1,
            DocumentoAnimal = 2
        }
    }
}
