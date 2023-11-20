using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<string> Create(UserDto userDto);
        Task<string> Update(UserDto userDto);
        Task<string> Delete(int id);
    }
}
