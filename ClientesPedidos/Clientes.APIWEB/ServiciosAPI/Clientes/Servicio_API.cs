using Clientes.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace Clientes.APIWEB
{
    public class Servicio_API : IServicio_API
    {
        public static string? _baseUrl;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value!;
        }

        public async Task<List<MostrarClienteDTO>> ListarClientes()
        {
            List<MostrarClienteDTO> ListaClientes = new List<MostrarClienteDTO>();

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.GetAsync("api/Cliente/Obtenertodos");

            if(response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<MostrarClienteDTO>>(json_respuesta);

                ListaClientes = resultado!;
            }
            return ListaClientes;
        }

        public async Task<MostrarClienteDTO> ObtenerPorId(int idCliente)
        {
            MostrarClienteDTO Objeto = new MostrarClienteDTO();

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.GetAsync($"api/Cliente/ListarporID/{idCliente}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<MostrarClienteDTO>(json_respuesta);
                return resultado!;
            }
            return Objeto;
        }

        public async Task<bool> GuardarCliente(CreacionClienteDTO modelo)
        {

            bool respuesta = false;

            var peticion = new HttpClient();
            
            peticion.BaseAddress = new Uri(_baseUrl!);                           
           
            var response = await peticion.PostAsJsonAsync("api/Cliente/Registrar", modelo);

            if (response.IsSuccessStatusCode)
            {
               respuesta = true;
            }

            return respuesta;
           
        }

        public async Task<bool> EditarCliente(CreacionClienteDTO modelo)
        {

            bool respuesta = false;

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.PutAsJsonAsync("api/Cliente/Actualizar", modelo);            

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;            

        }

        public async Task<bool> BorrarCliente(int idCliente)
        {
            bool respuesta = false;

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);           

            var response = await peticion.DeleteAsync($"api/Cliente/Eliminar/{idCliente}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;           

        }                         
    }
}
