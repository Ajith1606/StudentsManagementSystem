using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class ParentService : IParentRepository
    {
        private readonly HttpClient _httpClient;
        public ParentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Parent> AddAsync(Parent mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Parents/Add-Parent", mod);
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }

        public async Task<Parent> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/Parents/Delete-Parent/{id}");
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            var allparent = await _httpClient.GetAsync("api/Parents/All-Parents");
            var response = await allparent.Content.ReadFromJsonAsync<List<Parent>>();
            return response;
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            var singleparent = await _httpClient.GetAsync($"api/Parents/Single-Parent/{id}");
            var response = await singleparent.Content.ReadFromJsonAsync<Parent>();
            return response;
        }

        public async Task<Parent> UpdateAsync(Parent mod)
        {
            var newparent = await _httpClient.PostAsJsonAsync("api/Parents/Update-Parent", mod);
            var response = await newparent.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
    }
}
