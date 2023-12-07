using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly HttpClient _httpClient;

        public UserCourseRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<UserCourseDto>> GetAllUserCourses()
        {
            var response = await _httpClient.GetAsync("api/UserCourse");

            return await response.Content.ReadFromJsonAsync<ICollection<UserCourseDto>>();
        }

        public async Task<string> Create(UserCourseDto userCourseDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserCourse", userCourseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(UserCourseDto userCourseDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserCourse/Delete", userCourseDto);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
