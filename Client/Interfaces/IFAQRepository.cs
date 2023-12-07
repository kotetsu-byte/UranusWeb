using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IFAQRepository
    {
        Task<ICollection<FAQDto>> GetAllFAQs(int courseId, int aboutId);
        Task<FAQDto> GetFAQById(int courseId, int aboutId, int id);
        Task<string> Create(int courseId, int aboutId, FAQDto faq);
        Task<string> Update(FAQDto faq);
        Task<string> Delete(int id);
    }
}
