using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui.Demo.Mvvm;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;

namespace WPF_UI.Services
{
    internal class HttpJsonService<T> : IHttpJsonProvider<T> where T : class
    {
        public static string Token = string.Empty;

        LoginDTO loginDTO = App.Services.GetService<Credenciales>().GetCredenciales();


        public async Task<IEnumerable<T?>> GetAsync(string path)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
                    HttpResponseMessage request = await httpClient.GetAsync($"{ConstantesApi.BASE_URL}{path}");
                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.GetAsync($"{ConstantesApi.BASE_URL}{path}");
                    }
                    string dataRequest = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<T>>(dataRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request)
        {

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.LOGIN_PATH}/login", httpContent);

            string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
            UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

            Token = tokenUser?.Result?.Token ?? string.Empty;
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");


        }

        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                App.Services.GetService<Credenciales>().SetCredenciales(loginDTO);

                using HttpClient httpClient = new HttpClient();
                {
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
                    HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.LOGIN_PATH}/login", httpContent);

                    string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
                    UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

                    Token = tokenUser?.Result?.Token ?? string.Empty;
                    httpClient.DefaultRequestHeaders.Remove("Authorization");
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

                    return tokenUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task<UserDTO> RegistroAsync(RegistroDTO registroDTO)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                {
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(registroDTO), Encoding.UTF8, "application/json");
                    HttpResponseMessage requestToken = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{ConstantesApi.LOGIN_PATH}/register", httpContent);

                    string dataTokenRequest = await requestToken.Content.ReadAsStringAsync();
                    UserDTO tokenUser = JsonSerializer.Deserialize<UserDTO>(dataTokenRequest);

                    return tokenUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }



        public async Task<T?> PostAsync(string path, T data)
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

                    HttpResponseMessage response = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{path}", content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, response);

                        // Realizar la solicitud POST
                        response = await httpClient.PostAsync($"{ConstantesApi.BASE_URL}{path}", content);

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

        public async Task<T?> PatchAsync(string path, T data)
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
                    HttpResponseMessage request = await httpClient.PatchAsync($"{ConstantesApi.BASE_URL}{path}", content);

                    if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await Authenticate(path, httpClient, request);
                        request = await httpClient.PatchAsync($"{ConstantesApi.BASE_URL}{path}", content);

                        if (request.IsSuccessStatusCode)
                        {
                            string responseBody = await request.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<T?>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
    }
 }
