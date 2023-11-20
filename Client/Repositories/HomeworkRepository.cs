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

        public async Task<IEnumerable<HomeworkDto>> GetAllHomeworks()
        {
            var response = await _httpClient.GetAsync("/api/Homework");

            return await response.Content.ReadFromJsonAsync<IEnumerable<HomeworkDto>>();
        }

        public async Task<HomeworkDto> GetHomeworkById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Homework/{id}");

            return await response.Content.ReadFromJsonAsync<HomeworkDto>();
        }

        public async Task<string> Create(HomeworkDto homeworkDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    title = homeworkDto.Title,
                    description = homeworkDto.Description,
                    deadline = homeworkDto.Deadline
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/Homework", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(HomeworkDto homeworkDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = homeworkDto.Id,
                    title = homeworkDto.Title,
                    description = homeworkDto.Description,
                    deadline = homeworkDto.Deadline
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/Homework", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Homework/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
