using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly HttpClient _httpClient;

        public MaterialRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterials(int courseId, int lessonId, int homeworkId)
        {
            var response = await _httpClient.GetAsync($"/api/Material/{courseId}/{lessonId}/{homeworkId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<MaterialDto>>();
        }

        public async Task<MaterialDto> GetMaterialById(int courseId, int lessonId, int homeworkId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Material/{courseId}/{lessonId}/{homeworkId}/{id}");

            return await response.Content.ReadFromJsonAsync<MaterialDto>();
        }

        public async Task<string> Create(int courseId, int lessonId, int homeworkId, MaterialDto materialDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Material/{courseId}/{lessonId}/{homeworkId}", materialDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(MaterialDto materialDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("/api/Material", materialDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Material/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
