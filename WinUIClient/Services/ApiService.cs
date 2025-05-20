using ArcadeLauncherClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace ArcadeLauncherClient.Services
{
    public static class ApiService
    {
        private static readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:5001/api/") };

        public static async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("auth/login", request);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<AuthResponse>() : null;
        }

        public static async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
        {
            var response = await _http.PostAsJsonAsync("auth/register", request);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<AuthResponse>() : null;
        }
    }
}