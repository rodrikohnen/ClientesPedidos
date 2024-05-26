﻿namespace Clientes.BLL
{
    public interface IGenericoServicio<DTOCreacion, DTO>
    {
        Task<DTO> Registrar(DTOCreacion modelo);

        Task<DTO> Actualizar(int? id, DTOCreacion modelo);

        Task<bool> Eliminar(int? id);

        Task<DTO> ObtenerPorId(int? id);

        Task<List<DTO>> ObtenerTodos();
    }
}
