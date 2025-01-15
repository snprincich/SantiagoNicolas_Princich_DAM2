using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using BasicApp.DTO;
using System.Security.Policy;
using System.Reflection.Metadata;

namespace BasicApp.Utils
{
    public static class HttpJsonClient<T>
    {
        public static string Token = string.Empty;

        //CREAR UN METODO SOLO PARA LA RENOVACION DE TOKEN ASI NO HAY QUE ESCRIBIRLO EN EL GET, POST Y PATCH
        public static async Task<T?> Get(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
                    HttpResponseMessage request = await httpClient.GetAsync($"{Constantes.BASE_URL}{path}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.GetAsync($"{Constantes.BASE_URL}{path}");
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        private static async Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request)
        {
            LoginDTO loginDTO = new LoginDTO
            {
                Password = "wnD/LbJq?9t,}-628%)",
                UserName = "sufrido"
            };
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage requestToken = await httpClient.PostAsync($"{Constantes.BASE_URL}{Constantes.LOGIN_PATH}/login", httpContent);

            string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
            UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

            Token = tokenUser?.Result?.Token ?? string.Empty;
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
        }

        public static async Task<object> Post(string path, object data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

                    // Serializar el objeto 'data' (PokemonDTO) a JSON
                    string jsonContent = JsonSerializer.Serialize(data);

                    // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync($"{Constantes.BASE_URL}{path}", content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, response);

                        // Realizar la solicitud POST
                        response = await httpClient.PostAsync($"{Constantes.BASE_URL}{path}", content);

                        // Verificar si la respuesta fue exitosa
                        if (response.IsSuccessStatusCode)
                        {
                            // Leer el contenido de la respuesta y deserializarlo
                            string responseBody = await response.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        else
                        {
                            Console.WriteLine("Error en la respuesta: " + response.StatusCode);
                        }
                    }
                    string dataRequest = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
            }
            return default;
        }

        public static async Task<object> Patch(string path, object data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Agregar encabezado Authorization si es necesario
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

                    // Serializar el objeto 'data' (dto) a JSON
                    string jsonContent = JsonSerializer.Serialize(data,
                     new JsonSerializerOptions
                     {
                         DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                         WriteIndented = true  // Hace que el JSON sea más legible (con saltos de línea y espacios)
                     });

                    // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Realizar la solicitud PATCH
                    HttpResponseMessage request = await httpClient.PatchAsync($"{Constantes.BASE_URL}{path}", content);

                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.PatchAsync($"{Constantes.BASE_URL}{path}", content);

                        if (request.IsSuccessStatusCode)
                        {
                            string responseBody = await request.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<object>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        else
                        {
                            Console.WriteLine("Error en la respuesta: " + request.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud PATCH: {ex.Message}");
            }
            return default;
        }


        public static async Task<bool> DeleteAll(string url)
        {
            using HttpClient httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error:{response.StatusCode}");
                Console.WriteLine($"Detalles:{errorDetails}");
                return false;
            }
            return true;
        }

    }
}
