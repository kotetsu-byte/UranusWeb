using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IUserCourseRepository
    {
        Task<ICollection<UserCourseDto>> GetAllUserCourses();
        Task<string> Create(UserCourseDto userCourse);
        Task<string> Delete(UserCourseDto userCourse);
    }
}
