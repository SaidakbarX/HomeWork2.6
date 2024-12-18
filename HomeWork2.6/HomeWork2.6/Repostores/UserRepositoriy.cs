using HomeWork2._6.DateAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeWork2._6.Repostores;

public class UserRepositoriy : IUserRepositoriy
{
    private string path;
    private List<User> _users;
    public UserRepositoriy()
    {     path  = "../../../DateAccess/Date/User.json";
        _users = new List<User>();
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");

        }
        _users = ReadUser();
    }

    public bool checkEmailContains(string email)
    {
        var user = ReadUser();
        foreach (var item in user)
        {
            if (item.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public object CheckEmailContains(string email)
    {
        throw new NotImplementedException();
    }

    public List<User> ReadUser()
    {
        var usersJson = File.ReadAllText(path);
        var users = JsonSerializer.Deserialize<List<User>>(usersJson);
        return users;
    }

    public User ReadUserById(Guid Id)
    {
        foreach (var user in _users)
        {
            if (user.Id == Id)
            {
                return user;
            }
        }
        return null;
    }

    public bool RemoveUser(Guid Id)
    {
        var removingUser = ReadUserById(Id);
        if (removingUser is null)
        {
            return false;
        }
        _users.Remove(removingUser);
        SaveData();
        return true;
    }

    public bool UpdateUser(User user)
    {
        var updatingUser = ReadUserById(user.Id);
        if (updatingUser is null)
        {
            return false;   
        }
        var index = _users.IndexOf(updatingUser);
        _users[index] = user;
        SaveData();
        return true;
    }

    public User WriteUser(User user)
    {
        _users.Add(user);
        SaveData();
        return user;
    }
    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(_users);
        File.WriteAllText(path,jsonData);
    }
    
}
