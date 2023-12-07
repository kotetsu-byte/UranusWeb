using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly HttpClient _httpClient;

        public ResultRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<ResultDto>> GetAllResults(int courseId, int aboutId)
        {
            var response = await _httpClient.GetAsync($"api/Result/{courseId}/{aboutId}");

            return await response.Content.ReadFromJsonAsync<ICollection<ResultDto>>();
        }

        public async Task<ResultDto> GetResultById(int courseId, int aboutId, int id)
        {
            var response = await _httpClient.GetAsync($"api/Result/{courseId}/{aboutId}/{id}");

            return await response.Content.ReadFromJsonAsync<ResultDto>();
        }
    }
}
