using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly HttpClient _httpClient;

        public LessonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LessonDto>> GetAllLessons()
        {
            var response = await _httpClient.GetAsync("/api/Lesson");

            return await response.Content.ReadFromJsonAsync<IEnumerable<LessonDto>>();
        }

        public async Task<LessonDto> GetLessonById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Lesson/{id}");

            return await response.Content.ReadFromJsonAsync<LessonDto>();
        }

        public async Task<string> Create(LessonDto lessonDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    title = lessonDto.Title,
                    content = lessonDto.Content
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/Lesson", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(LessonDto lessonDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = lessonDto.Id,
                    title = lessonDto.Title,
                    content = lessonDto.Content
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/Lesson", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Lesson/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
