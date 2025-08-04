using DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace WindowsForms
{
    internal class EspecialidadApiClient
    {
        private static HttpClient client = new HttpClient();
        static EspecialidadApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7003/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Especialidad> GetAsync(int id)
        {
            Especialidad especialidad = null;
            HttpResponseMessage response = await client.GetAsync("especialidades/" + id);//ver bien ruta
            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadFromJsonAsync<Especialidad>();
            }
            return especialidad;
        }

        public static async Task<IEnumerable<Especialidad>> GetAllAsync()
        {
            HttpResponseMessage response = await client.GetAsync("especialidades");
            if (response.IsSuccessStatusCode)
            {
                var especialidades = await response.Content.ReadFromJsonAsync<IEnumerable<Especialidad>>();
                if (especialidades == null)
                {
                    // Log o mensaje de error
                    Console.WriteLine("La deserialización devolvió null.");
                }
                return especialidades;
            }
            else
            {
                // Log o mensaje de error
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en la respuesta: {response.StatusCode} - {error}");
            }
            return Enumerable.Empty<Especialidad>();
        }

        public async static Task AddAsync(Especialidad especialidad)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("especialidades/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Especialidad especialidad)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }
    }
}