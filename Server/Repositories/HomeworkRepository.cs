using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.JavaScript;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly AppDbContext _context;

        public HomeworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Homework>> GetAllHomeworks(int courseId, int lessonId)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId).ToListAsync();
        }

        public async Task<Homework> GetHomeworkById(int courseId, int lessonId, int id)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId && h.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Homework homework)
        {
            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool Update(Homework homework)
        {
            _context.Homeworks.Update(homework);

            return Save();
        }

        public bool Delete(int id)
        {
            var homework = _context.Homeworks.Where(h => h.Id == id).FirstOrDefault();
            
            _context.Homeworks.Remove(homework);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
