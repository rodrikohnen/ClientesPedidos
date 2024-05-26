using AutoMapper;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;
using Clientes.DAL.Dbcontext;


namespace Clientes.DAL
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ClienteRepositorio(AplicationDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<MostrarClienteDTO> Actualizar(int? id, CreacionClienteDTO modelo)
        {
            var cliente = await _dbcontext.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (cliente == null) throw new NotFoundException();

            cliente.Id = id;
            cliente.NameLastname = modelo.NameLastname;
            cliente.NroDocumento = modelo.NroDocumento;
            cliente.TipoDeDocumento = modelo.TipoDeDocumento;
            cliente.FechadeNacimiento = DateTime.ParseExact(modelo.FechadeNacimiento!, "dd/MM/yyyy", null);
            cliente.FechaHoraActualizacion = modelo.FechaHoraActualizacion;

            _dbcontext.Update(cliente);
            await _dbcontext.SaveChangesAsync();

            return _mapper.Map<MostrarClienteDTO>(cliente);
        }

        public async Task<bool> Eliminar(int id)
        {
            var cliente = await _dbcontext.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (cliente == null) throw new NotFoundException();
            _dbcontext.Remove(cliente);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<MostrarClienteDTO> Insertar(CreacionClienteDTO modelo)
        {
            try
            {                   
                var clienteAdd = _mapper.Map<Cliente>(modelo);
                clienteAdd.FechadeNacimiento = DateTime.ParseExact(modelo.FechadeNacimiento!, "dd/MM/yyyy", null);
                _dbcontext.Add(clienteAdd);
                await _dbcontext.SaveChangesAsync();
                return _mapper.Map<MostrarClienteDTO>(clienteAdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<MostrarClienteDTO> ObtenerPorId(int id)
        {
            var cliente = await _dbcontext.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (cliente == null) throw new NotFoundException();
            return _mapper.Map<MostrarClienteDTO>(cliente);

        }

       public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            try
            {
                IQueryable<Cliente> queryClientes = _dbcontext.Clientes;
                return queryClientes;
            }
            catch
            {
                throw new BadRequestException();
            }
        }
    }
}
