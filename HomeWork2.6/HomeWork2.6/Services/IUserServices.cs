using HomeWork2._6.Services.DTOs;

namespace HomeWork2._6.Services;

public interface IUserServices
{
    UserDto AddUser(UserCreatDto user);
    bool DeleteUser (Guid id);
    bool UserUpdate (UserUpdateDto user);
    List<UserDto> GetUsers ();
    bool checkEmailContains (string email);
}