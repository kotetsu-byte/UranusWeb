using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Course course)
        {
            _context.Courses.Add(course);

            return Save();
        }

        public bool Update(Course course)
        {
            _context.Courses.Update(course);

            return Save();
        }

        public bool Delete(Course course)
        {
            _context.Courses.Remove(course);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
