using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        bool Save();
    }
}
