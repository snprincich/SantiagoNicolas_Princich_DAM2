using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_UI.DTO;

namespace WPF_UI.Interface
{
    public interface IHttpJsonProvider<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(string path);
        Task Authenticate(string path, HttpClient httpClient, HttpResponseMessage request);
        Task<T?> PatchAsync(string path, T data);
        Task<T?> PostAsync(string path, T data);
        Task<UserDTO> LoginAsync(LoginDTO loginDTO);
    }
}
