using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class PartVideoRepository : IPartVideoRepository
    {
        private readonly HttpClient _httpClient;

        public PartVideoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<PartVideoDto>> GetAllPartVideos(int courseId, int aboutId)
        {
            var response = await _httpClient.GetAsync($"api/PartVideo/{courseId}/{aboutId}");

            return await response.Content.ReadFromJsonAsync<ICollection<PartVideoDto>>();
        }

        public async Task<PartVideoDto> GetPartVideoById(int courseId, int aboutId, int id)
        {
            var response = await _httpClient.GetAsync($"api/PartVideo/{courseId}/{aboutId}/{id}");

            return await response.Content.ReadFromJsonAsync<PartVideoDto>();
        }

        public async Task<string> Create(int courseId, int aboutId, PartVideoDto partVideoDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/PartVideo/{courseId}/{aboutId}", partVideoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(PartVideoDto partVideoDto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/PartVideo", partVideoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/PartVideo/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
