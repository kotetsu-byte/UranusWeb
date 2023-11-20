using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HttpClient _httpClient;

        public CourseRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var response = await _httpClient.GetAsync("api/Course");

            return await response.Content.ReadFromJsonAsync<IEnumerable<CourseDto>>();
        }

        public async Task<CourseDto> GetCourseById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Course/{id}");

            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<string> Create(CourseDto courseDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                    {
                        name = courseDto.Name,
                        description = courseDto.Description,
                        price = courseDto.Price
                    }
                ),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("api/Course", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(CourseDto courseDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = courseDto.Id,
                    name = courseDto.Name,
                    description = courseDto.Description,
                    price = courseDto.Price
                }
                ),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("api/Course", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Course/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
