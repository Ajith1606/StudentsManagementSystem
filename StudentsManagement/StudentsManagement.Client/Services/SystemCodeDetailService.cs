using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class SystemCodeDetailService : ISystemCodeDetailsRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeDetailService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<SystemCodeDetails> AddAsync(SystemCodeDetails systemcodedetails)
        {
            var data = await _httpClient.PostAsJsonAsync("api/SystemCodeDetails/Add-SystemCodeDetails", systemcodedetails);
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetails>();
            return response;
        }

        public async Task<SystemCodeDetails> DeleteAsync(int systemcodedetailsId)
        {
            var data = await _httpClient.DeleteAsync($"api/SystemCodeDetails/Delete-SystemCodeDetails/{systemcodedetailsId}");
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetails>();
            return response;
        }

        public async Task<List<SystemCodeDetails>> GetAllAsync()
        {
            var allcountry = await _httpClient.GetAsync("api/SystemCodeDetails/All-SystemCodeDetails");
            var response = await allcountry.Content.ReadFromJsonAsync<List<SystemCodeDetails>>();
            return response;
        }
        public async Task<SystemCodeDetails> GetByIdAsync(int systemcodedetailsId)
        {
            var singlecountry = await _httpClient.GetAsync($"api/SystemCodeDetails/Single-SystemCodeDeatils/{systemcodedetailsId}");
            var response = await singlecountry.Content.ReadFromJsonAsync<SystemCodeDetails>();
            return response;
        }

        public async Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails systemcodedetails)
        {
            var newcountry = await _httpClient.PostAsJsonAsync("api/SystemCodeDetails/Update-SystemCodeDetails", systemcodedetails);
            var response = await newcountry.Content.ReadFromJsonAsync<SystemCodeDetails>();
            return response;
        }
    }
}
