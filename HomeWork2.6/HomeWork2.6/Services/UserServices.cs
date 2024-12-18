using HomeWork2._6.DateAccess.Entities;
using HomeWork2._6.Repostores;
using HomeWork2._6.Services.DTOs;

namespace HomeWork2._6.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepositoriy _userRepositoriy;
    public UserServices()
    {
        _userRepositoriy = new UserRepositoriy();
    }

    public UserDto AddUser(UserCreatDto user)
    {
        var checkingEmail =(bool)_userRepositoriy.CheckEmailContains(user.Email);
        if (!user.Email.EndsWith("@gmail.com") || checkingEmail)
        {
            return null;
        }
        var users = ConvertToUser(user);
        var userFromDb = _userRepositoriy.WriteUser(users);
        var userDto = ConvertToDto(userFromDb);
        return userDto;
    }

    

    public bool DeleteUser(Guid id)
    {
        var res = _userRepositoriy.RemoveUser(id);
        return res;
    }

    public List<UserDto> GetUsers()
    { var users = _userRepositoriy.ReadUser();
        var userGetDto = new List<UserDto>();
        foreach (  var user in users )
        {
            userGetDto.Add(ConvertToDto(user));
        }
        return userGetDto;
    }

    public bool UserUpdate(UserUpdateDto user)
    {
        var users = ConvertToUser(user);
        var res = _userRepositoriy.UpdateUser(users);
        return res;
    }

    bool IUserServices.checkEmailContains(string email)
    {
        throw new NotImplementedException();
    }
    private User  ConvertToUser(UserCreatDto dto)
    {
        var users = new User()
        {
            Id = Guid.NewGuid(),
            Age = dto.Age,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Password = dto.Password,

        };
        return users;


    } 
    private User  ConvertToUser(UserUpdateDto dto)
    {
        var users = new User()
        {
            Id = dto.Id,
            Age = dto.Age,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Password = dto.Password,

        };
        return users;


    }
    private UserDto  ConvertToDto (User user)
    {
        var dto = new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Age = user.Age,
        };
        return dto;
    }
}
