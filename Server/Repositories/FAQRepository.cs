using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private readonly AppDbContext _context;

        public FAQRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FAQ>> GetAllFAQs(int courseId, int aboutId)
        {
            return await _context.FAQs.Where(f => f.CourseId == courseId && f.AboutId == aboutId).ToListAsync();
        }

        public async Task<FAQ> GetFAQById(int courseId, int aboutId, int id)
        {
            return await _context.FAQs.Where(f => f.CourseId == courseId && f.AboutId == aboutId && f.Id == id).FirstOrDefaultAsync(); 
        }

        public bool Create(FAQ faq)
        {
            _context.FAQs.Add(faq);

            return Save();
        }

        public bool Update(FAQ faq)
        {
            _context.FAQs.Update(faq);

            return Save();
        }

        public bool Delete(int id)
        {
            var faq = _context.FAQs.Where(f => f.Id == id).FirstOrDefault();

            _context.FAQs.Remove(faq);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
