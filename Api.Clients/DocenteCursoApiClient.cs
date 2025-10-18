using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api.Clients
{
    public class DocenteCursoApiClient
    {
        private static HttpClient client = new HttpClient();
        
        static DocenteCursoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5255/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<DocenteCursoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"docentecursos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<DocenteCursoDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener asignación de docente con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener asignación de docente con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener asignación de docente con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("docentecursos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de asignaciones de docentes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de asignaciones de docentes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de asignaciones de docentes: {ex.Message}", ex);
            }
        }

        public async static Task<DocenteCursoDTO> AddAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("docentecursos", docenteCurso);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear asignación de docente. Status: {response.StatusCode}, Detalle: {errorContent}");
                }

                return await response.Content.ReadFromJsonAsync<DocenteCursoDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear asignación de docente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear asignación de docente: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"docentecursos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar asignación de docente con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar asignación de docente con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar asignación de docente con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("docentecursos", docenteCurso);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar asignación de docente con Id {docenteCurso.Id_dictado}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar asignación de docente con Id {docenteCurso.Id_dictado}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar asignación de docente con Id {docenteCurso.Id_dictado}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<DocenteCursoDTO>> GetByDocenteAsync(int idDocente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"docentecursos/docente/{idDocente}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener asignaciones para el docente {idDocente}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener asignaciones para el docente {idDocente}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener asignaciones para el docente {idDocente}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<DocenteCursoDTO>> GetByCursoAsync(int idCurso)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"docentecursos/curso/{idCurso}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener asignaciones para el curso {idCurso}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener asignaciones para el curso {idCurso}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener asignaciones para el curso {idCurso}: {ex.Message}", ex);
            }
        }
    }
}
