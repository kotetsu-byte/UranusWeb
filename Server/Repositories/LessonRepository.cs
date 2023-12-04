using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessons(int courseId)
        {
            return await _context.Lessons.Where(l => l.CourseId == courseId).ToListAsync();
        }

        public async Task<Lesson> GetLessonById(int courseId, int id)
        {
            return await _context.Lessons.Where(l => l.CourseId == courseId && l.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Lesson lesson)
        {
            _context.Lessons.Add(lesson);

            return Save();
        }

        public bool Update(Lesson lesson)
        {
            _context.Lessons.Update(lesson);

            return Save();
        }

        public bool Delete(int id)
        {
            var lesson = _context.Lessons.Where(l => l.Id == id).FirstOrDefault();
            
            _context.Lessons.Remove(lesson);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
