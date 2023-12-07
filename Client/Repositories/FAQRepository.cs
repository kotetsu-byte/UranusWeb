using System.Net.Http.Json;
using UranusWeb.Client.Interfaces;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private readonly HttpClient _httpClient;

        public FAQRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<FAQDto>> GetAllFAQs(int courseId, int aboutId)
        {
            var response = await _httpClient.GetAsync($"api/FAQ/{courseId}/{aboutId}");

            return await response.Content.ReadFromJsonAsync<ICollection<FAQDto>>();
        }

        public async Task<FAQDto> GetFAQById(int courseId, int aboutId, int id)
        {
            var response = await _httpClient.GetAsync($"api/FAQ/{courseId}/{aboutId}/{id}");

            return await response.Content.ReadFromJsonAsync<FAQDto>();
        }

        public async Task<string> Create(int courseId, int aboutId, FAQDto faqDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/FAQ/{courseId}/{aboutId}", faqDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(FAQDto faqDto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/FAQ", faqDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/FAQ/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
