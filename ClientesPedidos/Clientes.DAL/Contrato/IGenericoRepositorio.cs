namespace Clientes.DAL
{
    public interface IGenericoRepositorio<DTOCreacion, DTO, Entidad>
    {
        Task<DTO> Insertar(DTOCreacion modelo);

        Task<DTO> Actualizar(int? id, DTOCreacion modelo);

        Task<bool> Eliminar(int id);

        Task<DTO> ObtenerPorId(int id);

        Task<IQueryable<Entidad>> ObtenerTodos();
    }
}
