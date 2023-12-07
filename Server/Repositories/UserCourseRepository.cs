using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly AppDbContext _context;

        public UserCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserCourse>> GetAllUserCourses()
        {
            return await _context.UserCourses.ToListAsync();
        }

        public bool Create(UserCourse userCourse)
        {
            _context.UserCourses.Add(userCourse);

            return Save();
        }

        public bool Delete(UserCourse userCourse)
        {
            _context.UserCourses.Remove(userCourse);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
