using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly HttpClient _httpClient;

        public TestRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TestDto>> GetAllTests(int courseId)
        {
            var response = await _httpClient.GetAsync($"/api/Test/{courseId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<TestDto>>();
        }

        public async Task<TestDto> GetTestById(int courseId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Test/{courseId}/{id}");

            return await response.Content.ReadFromJsonAsync<TestDto>();
        }

        public async Task<string> Create(int courseId, TestDto testDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Test/{courseId}", testDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(TestDto testDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("/api/Test", testDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Test/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
