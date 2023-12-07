using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetAllReviews(int courseId, int aboutId);
        Task<Review> GetReviewById(int courseId, int aboutId, int id);
        bool Create(Review review);
        bool Update(Review review);
        bool Delete(int id);
        bool Save();
    }
}
