using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Api.Clients
{
    public class UsuarioApiClient
    {
        private static HttpClient client = new HttpClient();
        static UsuarioApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5255/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<UsuarioDTO> AddAsync(UsuarioDTO usuario)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("usuarios", usuario);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear usuario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear usuario: {ex.Message}", ex);
            }
        }

        public static async Task<UsuarioDTO> GetByPersonaIdAsync(int idPersona)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/persona/{idPersona}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener usuario para la persona con Id {idPersona}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener usuario para la persona con Id {idPersona}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener usuario para la persona con Id {idPersona}: {ex.Message}", ex);
            }
        }
    }
}