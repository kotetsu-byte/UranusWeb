using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HttpClient _httpClient;

        public ReviewRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<ReviewDto>> GetAllReviews(int courseId, int aboutId)
        {
            var response = await _httpClient.GetAsync($"api/Review/{courseId}/{aboutId}");

            return await response.Content.ReadFromJsonAsync<ICollection<ReviewDto>>();
        }

        public async Task<ReviewDto> GetReviewById(int courseId, int aboutId, int id)
        {
            var response = await _httpClient.GetAsync($"api/Review/{courseId}/{aboutId}/{id}");

            return await response.Content.ReadFromJsonAsync<ReviewDto>();
        }

        public async Task<string> Create(int courseId, int aboutId, ReviewDto reviewDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Review/{courseId}/{aboutId}", reviewDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(ReviewDto reviewDto)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/Review", reviewDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Review/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
