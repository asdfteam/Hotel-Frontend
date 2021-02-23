using System.Threading.Tasks;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Hotel_Frontend.Services
{

    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem(string key);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime IjsRuntime { get; set; }

        public LocalStorageService(IJSRuntime ijsRuntime)
        {
            IjsRuntime = ijsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var response = await IjsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return response == null ? default : JsonConvert.DeserializeObject<T>(response);
        }

        public async Task SetItem<T>(string key, T value)
        {
            await IjsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonConvert.SerializeObject(value));
        }

        public async Task RemoveItem(string key)
        {
            await IjsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}