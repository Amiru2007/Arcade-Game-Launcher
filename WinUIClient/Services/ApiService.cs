// File: Services/ApiService.cs
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ArcadeLauncherClient.Models;

namespace WinUIClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7137/");
        }

        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var loginData = new LoginRequest { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginData);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<AuthResponse> RegisterAsync(string username, string email, string password)
        {
            var registerData = new RegisterRequest { Username = username, Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerData);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }
    }
}
