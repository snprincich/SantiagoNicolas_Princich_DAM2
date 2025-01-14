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
                    HttpResponseMessage request = await httpClient.GetAsync($"{Constantes.BASE_URL}{path}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);

                        // Serializar el objeto 'data' (PokemonDTO) a JSON
                        string jsonContent = JsonSerializer.Serialize(data);

                        // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        // Realizar la solicitud POST
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);

                        request = await httpClient.GetAsync($"{Constantes.BASE_URL}{path}");

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
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
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
