using Clientes.Models;
using Newtonsoft.Json;

namespace Clientes.APIWEB
{
    public class ServiciosAPIproductos : IServiciosAPIproductos
    {
        public static string? _baseUrl;

        public ServiciosAPIproductos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value!;
        }

        public async Task<List<MostrarProductoDTO>> ListarProductos()
        {
            List<MostrarProductoDTO> listaProductos = new List<MostrarProductoDTO>();

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.GetAsync("api/Producto/Obtenertodos");

            if(response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<MostrarProductoDTO>>(json_respuesta);

                listaProductos = resultado!;
            }
            return listaProductos;
        }

        public async Task<MostrarProductoDTO> ObtenerPorId(int idProducto)
        {
            MostrarProductoDTO Objeto = new MostrarProductoDTO();

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.GetAsync($"api/Producto/ListarporID/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<MostrarProductoDTO>(json_respuesta);
                return resultado!;
            }
            return Objeto;
        }

        public async Task<bool> Guardar(CreacionProductoDTO modelo)
        {

            bool respuesta = false;

            var peticion = new HttpClient();

            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.PostAsJsonAsync("api/Producto/Registrar", modelo);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;

        }

        public async Task<bool> Editar(CreacionProductoDTO modelo)
        {

            bool respuesta = false;

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.PutAsJsonAsync("api/Producto/Actualizar", modelo);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;

        }
        public async Task<bool> Borrar(int idProducto)
        {
            bool respuesta = false;

            var peticion = new HttpClient();
            peticion.BaseAddress = new Uri(_baseUrl!);

            var response = await peticion.DeleteAsync($"api/Producto/Eliminar/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;

        }

    }
}
