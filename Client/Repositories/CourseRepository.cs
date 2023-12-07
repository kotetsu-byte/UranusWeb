using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HttpClient _httpClient;

        public CourseRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<CourseDto>> GetAllCourses()
        {
            var response = await _httpClient.GetAsync("api/Course");

            return await response.Content.ReadFromJsonAsync<ICollection<CourseDto>>();
        }

        public async Task<CourseDto> GetCourseById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Course/{id}");

            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<string> Create(CourseDto courseDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Course", courseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(CourseDto courseDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Course", courseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Course/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
