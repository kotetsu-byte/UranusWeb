using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<About>> GetAllAbouts(int courseId)
        {
            return await _context.Abouts.Where(a => a.CourseId == courseId).ToListAsync();
        }

        public async Task<About> GetAboutById(int courseId, int id)
        {
            return await _context.Abouts.Where(a => a.CourseId == courseId && a.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(About about)
        {
            _context.Abouts.Add(about);

            return Save();
        }

        public bool Update(About about)
        {
            _context.Abouts.Update(about);

            return Save();
        }

        public bool Delete(int id) 
        {
            var about = _context.Abouts.Where(a => a.Id == id).FirstOrDefault();

            _context.Abouts.Remove(about);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
