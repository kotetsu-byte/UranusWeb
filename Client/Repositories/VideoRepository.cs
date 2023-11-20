using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly HttpClient _httpClient;

        public VideoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<VideoDto>> GetAllVideos()
        {
            var response = await _httpClient.GetAsync("/api/Video");

            return await response.Content.ReadFromJsonAsync<IEnumerable<VideoDto>>();
        }

        public async Task<VideoDto> GetVideoById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Video/{id}");

            return await response.Content.ReadFromJsonAsync<VideoDto>();
        }

        public async Task<string> Create(VideoDto videoDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    title = videoDto.Title,
                    url = videoDto.Url,
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/api/Video", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(VideoDto videoDto)
        {
            StringContent content = new(
                JsonSerializer.Serialize(new
                {
                    id = videoDto.Id,
                    title = videoDto.Title,
                    url = videoDto.Url,
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PatchAsync("/api/Video", content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Video/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
