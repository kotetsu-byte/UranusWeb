using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly HttpClient _httpClient;

        public DocRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DocDto>> GetAllDocs(int courseId, int lessonId)
        {
            var response = await _httpClient.GetAsync($"/api/Doc/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocDto>>();
        }

        public async Task<DocDto> GetDocById(int courseId, int lessonId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Doc/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<DocDto>();
        }

        public async Task<string> Create(int courseId, int lessonId, DocDto docDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Doc/{courseId}/{lessonId}", docDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(DocDto docDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Doc", docDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Doc/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
