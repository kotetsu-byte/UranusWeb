using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly HttpClient _httpClient;

        public LessonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LessonDto>> GetAllLessons(int courseId)
        {
            var response = await _httpClient.GetAsync($"/api/Lesson/{courseId}");

            return await response.Content.ReadFromJsonAsync<IEnumerable<LessonDto>>();
        }

        public async Task<LessonDto> GetLessonById(int courseId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Lesson/{courseId}/{id}");

            return await response.Content.ReadFromJsonAsync<LessonDto>();
        }

        public async Task<string> Create(int courseId, LessonDto lessonDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Lesson/{courseId}", lessonDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(LessonDto lessonDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("/api/Lesson}", lessonDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Lesson/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
