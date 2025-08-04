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

namespace WindowsForm
{
    internal class PersonaApiClient
    {
        private static HttpClient client = new HttpClient();
        static PersonaApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7003/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Persona> GetAsync(int id)
        {
            Persona persona = null;
            HttpResponseMessage response = await client.GetAsync("personas/" + id);
            if (response.IsSuccessStatusCode)
            {
                persona = await response.Content.ReadFromJsonAsync<Persona>();
            }
            return persona;
        }

        public static async Task<IEnumerable<Persona>> GetAllAsync()
        {
            HttpResponseMessage response = await client.GetAsync("personas");
            if (response.IsSuccessStatusCode)
            {
                var personas = await response.Content.ReadFromJsonAsync<IEnumerable<Persona>>();
                if (personas == null)
                {
                    // Log o mensaje de error
                    Console.WriteLine("La deserialización devolvió null.");
                }
                return personas;
            }
            else
            {
                // Log o mensaje de error
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en la respuesta: {response.StatusCode} - {error}");
            }
            return Enumerable.Empty<Persona>();
        }

        public async static Task AddAsync(Persona persona)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("personas", persona);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("personas/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Persona persona)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("personas", persona);
            response.EnsureSuccessStatusCode();
        }
    }
}

