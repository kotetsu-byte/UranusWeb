using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<ReviewDto>> GetAllReviews(int courseId, int aboutId);
        Task<ReviewDto> GetReviewById(int courseId, int aboutId, int id);
        Task<string> Create(int courseId, int aboutId, ReviewDto review);
        Task<string> Update(ReviewDto review);
        Task<string> Delete(int id);
    }
}
