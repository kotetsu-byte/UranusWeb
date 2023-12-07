using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly HttpClient _httpClient;

        public VideoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<VideoDto>> GetAllVideos(int courseId, int lessonId)
        {
            var response = await _httpClient.GetAsync($"/api/Video/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<ICollection<VideoDto>>();
        }

        public async Task<VideoDto> GetVideoById(int courseId, int lessonId, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Video/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<VideoDto>();
        }

        public async Task<string> Create(int courseId, int lessonId, VideoDto videoDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Video/{courseId}/{lessonId}", videoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(VideoDto videoDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Video", videoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Video/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
