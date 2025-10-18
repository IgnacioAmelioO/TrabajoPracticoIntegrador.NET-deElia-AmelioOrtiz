using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api.Clients
{
    public class AlumnoInscripcionApiClient
    {
        private static HttpClient client = new HttpClient();

        static AlumnoInscripcionApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5255/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<AlumnoInscripcionDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync("alumnoinscripciones/" + id);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<AlumnoInscripcionDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener inscripción {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripción {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("alumnoinscripciones");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<AlumnoInscripcionDTO>>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener inscripciones. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripciones: {ex.Message}", ex);
            }
        }

        // Nuevo: obtener inscripciones por Id_alumno (endpoint: /alumnoinscripciones/alumno/{id_alumno})
        public static async Task<IEnumerable<AlumnoInscripcionDTO>> GetByAlumnoAsync(int id_alumno)
        {
            try
            {
                var response = await client.GetAsync($"alumnoinscripciones/alumno/{id_alumno}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<AlumnoInscripcionDTO>>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener inscripciones del alumno {id_alumno}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripciones del alumno {id_alumno}: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(AlumnoInscripcionDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("alumnoinscripciones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear inscripción. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear inscripción: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(AlumnoInscripcionDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("alumnoinscripciones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar inscripción {dto.Id_inscripcion}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar inscripción {dto.Id_inscripcion}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync("alumnoinscripciones/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar inscripción {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar inscripción {id}: {ex.Message}", ex);
            }
        }
    }
}