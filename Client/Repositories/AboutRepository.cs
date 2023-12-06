using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly HttpClient _httpClient;

        public AboutRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AboutDto>> GetAllAbouts(int courseId)
        {
            var response = await _httpClient.GetAsync($"api/About/{courseId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<AboutDto>>();
        }

        public async Task<AboutDto> GetAboutById(int courseId, int id)
        {
            var response = await _httpClient.GetAsync($"api/About/{courseId}/{id}");

            return await response.Content.ReadFromJsonAsync<AboutDto>();
        }

        public async Task<string> Create(int courseId, AboutDto aboutDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/About/{courseId}", aboutDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(AboutDto aboutDto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/About", aboutDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/About/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
