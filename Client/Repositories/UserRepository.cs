using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

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
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    firstName = userDto.FirstName,
                    lastName = userDto.LastName,
                    email = userDto.Email,
                    address = userDto.Address,
                    username = userDto.Username
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/User", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(UserDto userDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = userDto.Id,
                    firstName = userDto.FirstName,
                    lastName = userDto.LastName,
                    email = userDto.Email,
                    address = userDto.Address,
                    username = userDto.Username
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/User", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/User/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
