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

        public async Task<IEnumerable<TestDto>> GetAllTests()
        {
            var response = await _httpClient.GetAsync("/api/Test");

            return await response.Content.ReadFromJsonAsync<IEnumerable<TestDto>>();
        }

        public async Task<TestDto> GetTestById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Test/{id}");

            return await response.Content.ReadFromJsonAsync<TestDto>();
        }

        public async Task<string> Create(TestDto testDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    question = testDto.Question,
                    answer1 = testDto.Answer1,
                    answer2 = testDto.Answer2,
                    answer3 = testDto.Answer3,
                    answer4 = testDto.Answer4,
                    correctAnswer = testDto.CorrectAnswer,
                    points = testDto.Points
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/Test", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(TestDto testDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = testDto.Id,
                    question = testDto.Question,
                    answer1 = testDto.Answer1,
                    answer2 = testDto.Answer2,
                    answer3 = testDto.Answer3,
                    answer4 = testDto.Answer4,
                    correctAnswer = testDto.CorrectAnswer,
                    points = testDto.Points
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/Test", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Test/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
