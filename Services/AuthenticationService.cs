using System;
using System.Text;
using System.Threading.Tasks;
using Hotel_Frontend.Models;
using HttpClientImpl;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Hotel_Frontend.Services
{

    public interface IAuthenticationService
    {
        LoginModel User { get; }
        Task Initialize();
        Task Login(LoginModel model);
        Task Logout();
    }
    public class AuthenticationService : IAuthenticationService
    {
        public LoginModel User { get; private set; }

        private readonly IHttpClientImpl _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthenticationService(ILocalStorageService localStorageService, IHttpClientImpl httpClientImpl, NavigationManager navigationManager)
        {
            _localStorage = localStorageService;
            _httpClient = httpClientImpl;
            _navigationManager = navigationManager;
        }
        public async Task Initialize()
        {
            User = await _localStorage.GetItem<LoginModel>("user");
        }

        public async Task Login(LoginModel model)
        {
            
            const string uri = "http://localhost:5000/login";
            var jsonModel = JsonConvert.SerializeObject(model);
            var response = await _httpClient.Post(uri, jsonModel);
            if (response.IsSuccessStatusCode)
            {
                var authString = $"{model.UserName}";
                User = model;
                User.AuthData = authString;
                var result = await response.Content.ReadAsStringAsync();
                User.CustomerId = JsonConvert.DeserializeObject<LoginModel>(result).CustomerId;
                await _localStorage.SetItem("user", User);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task Logout()
        {
            User = null;
            await _localStorage.RemoveItem("user");
            _navigationManager.NavigateTo("/");
        }
    }
}