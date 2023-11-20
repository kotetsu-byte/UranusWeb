using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly HttpClient _httpClient;

        public MaterialRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterials()
        {
            var response = await _httpClient.GetAsync("/api/Material");

            return await response.Content.ReadFromJsonAsync<IEnumerable<MaterialDto>>();
        }

        public async Task<MaterialDto> GetMaterialById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Material/{id}");

            return await response.Content.ReadFromJsonAsync<MaterialDto>();
        }

        public async Task<string> Create(MaterialDto materialDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    title = materialDto.Title,
                    url = materialDto.Url
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/Material", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(MaterialDto materialDto)
        {
            StringContent content = new(
               JsonSerializer.Serialize(new
               {
                   id = materialDto.Id,
                   title = materialDto.Title,
                   url = materialDto.Url
               }),
               Encoding.UTF8,
               "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/Material", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Material/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
