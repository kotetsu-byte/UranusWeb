using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("/api/User");

            return await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/User/{id}");

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task<string> Create(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/User", userDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(UserDto userDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("/api/User", userDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/User/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
