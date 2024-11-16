namespace AppCuidandoPatitas.Interface
{
    public interface IGuardarConImagen<T>
    {
        bool Guardar(T Model, IFormFile imagen);
    }
}
