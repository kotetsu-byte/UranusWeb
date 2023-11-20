using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly HttpClient _httpClient;

        public DocRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DocDto>> GetAllDocs()
        {
            var response = await _httpClient.GetAsync("/api/Doc");

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocDto>>();
        }

        public async Task<DocDto> GetDocById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Doc/${id}");

            return await response.Content.ReadFromJsonAsync<DocDto>();
        }

        public async Task<string> Create(DocDto docDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    title = docDto.Title,
                    url = docDto.Url
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("api/Doc", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(DocDto docDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = docDto.Id,
                    title = docDto.Title,
                    url = docDto.Url
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("api/Doc", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Doc/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
