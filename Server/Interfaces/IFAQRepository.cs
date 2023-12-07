using Microsoft.AspNetCore.Mvc.ActionConstraints;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IFAQRepository
    {
        Task<ICollection<FAQ>> GetAllFAQs(int courseId, int aboutId);
        Task<FAQ> GetFAQById(int courseId, int aboutId, int id);
        bool Create(FAQ faq);
        bool Update(FAQ faq);
        bool Delete(int id);
        bool Save();
    }
}
