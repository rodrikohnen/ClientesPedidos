

namespace Clientes.DAL
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message = "Ha ocurrido un error") : base(message)
        {
        }
    }
}
