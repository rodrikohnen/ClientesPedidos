public class NotFoundException : Exception
{
    public NotFoundException(string? message = "No existe un registro con el ID especificado.") : base(message)
    {
    }
}