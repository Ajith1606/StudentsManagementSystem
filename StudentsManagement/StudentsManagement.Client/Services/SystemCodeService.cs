using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class SystemCodeService : ISystemCodeRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<SystemCode> AddAsync(SystemCode systemcode)
        {
            var data = await _httpClient.PostAsJsonAsync("api/SystemCode/Add-SystemCode", systemcode);
            var response = await data.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }

        public async Task<SystemCode> DeleteAsync(int systemcodeId)
        {
            var data = await _httpClient.DeleteAsync($"api/SystemCode/Delete-SystemCode/{systemcodeId}");
            var response = await data.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }

        public async Task<List<SystemCode>> GetAllAsync()
        {
            var allcountry = await _httpClient.GetAsync("api/SystemCode/All-SystemCodes");
            var response = await allcountry.Content.ReadFromJsonAsync<List<SystemCode>>();
            return response;
        }

        public async Task<SystemCode> GetByIdAsync(int systemcodeId)
        {
            var singlecountry = await _httpClient.GetAsync($"api/SystemCode/Single-SystemCode/{systemcodeId}");
            var response = await singlecountry.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }

        public async Task<SystemCode> UpdateAsync(SystemCode systemcode)
        {
            var newcountry = await _httpClient.PostAsJsonAsync("api/SystemCode/Update-SystemCode", systemcode);
            var response = await newcountry.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }
    }
}
