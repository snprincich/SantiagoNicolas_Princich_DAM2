﻿using BasicApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicApp.Utils
{
    //TODO DEBERÍA SER SERVICE
    //public class FileService<T> : IFileService<T> where T : class
    public static class HttpJsonClient<T> where T : class
    {
        public static async Task<T?> Get(string url)
        {
            try
            {
            using HttpClient httpClient = new HttpClient();
            {

                    HttpResponseMessage datos = await httpClient.GetAsync(url);
                    string dataget = await datos.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(dataget);
                
            }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T?);
            }
        }

        public static async Task<T?> GetLastID(string url)
        {
            using HttpClient httpClient = new HttpClient();
            {
                HttpResponseMessage datos = await httpClient.GetAsync(url);
                string dataget = await datos.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(dataget);
            }
        }

        public static async Task<object> Post(string url, object data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Serializar el objeto 'data' (PokemonDTO) a JSON
                    string jsonContent = JsonSerializer.Serialize(data);

                    // Crear el contenido HTTP con el tipo adecuado para enviar JSON
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

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

