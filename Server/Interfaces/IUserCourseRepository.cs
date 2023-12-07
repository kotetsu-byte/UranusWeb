using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IUserCourseRepository
    {
        Task<ICollection<UserCourse>> GetAllUserCourses();
        bool Create(UserCourse userCourse);
        bool Delete(UserCourse userCourse);
        bool Save();
    }
}
