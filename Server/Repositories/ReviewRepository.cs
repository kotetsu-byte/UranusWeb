using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Review>> GetAllReviews(int courseId, int aboutId)
        {
            return await _context.Reviews.Where(r => r.CourseId == courseId && r.AboutId == aboutId).ToListAsync();
        }

        public async Task<Review> GetReviewById(int courseId, int aboutId, int id)
        {
            return await _context.Reviews.Where(r => r.CourseId == courseId && r.AboutId == aboutId && r.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Review review)
        {
            _context.Reviews.Add(review);

            return Save();
        }

        public bool Update(Review review)
        {
            _context.Reviews.Update(review);

            return Save();
        }

        public bool Delete(int id)
        {
            var review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();

            _context.Reviews.Remove(review);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
