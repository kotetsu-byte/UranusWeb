using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly HttpClient _httpClient;

        public HomeworkRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HomeworkDto>> GetAllHomeworks(int courseId, int lessonId)
        {
            var response = await _httpClient.GetAsync($"/api/Homework/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<HomeworkDto>>();
        }

        public async Task<HomeworkDto> GetHomeworkById(int courseId, int lessonId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Homework/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<HomeworkDto>();
        }

        public async Task<string> Create(int courseId, int lessonId, HomeworkDto homeworkDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Homework", homeworkDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(HomeworkDto homeworkDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("/api/Homework", homeworkDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Homework/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
