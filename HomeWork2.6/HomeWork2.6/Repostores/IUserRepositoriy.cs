using HomeWork2._6.DateAccess.Entities;

namespace HomeWork2._6.Repostores;

public interface IUserRepositoriy
{
     User WriteUser(User user);
    bool RemoveUser(Guid Id);
    bool UpdateUser(User user);
   User ReadUserById(Guid Id);
   
   List <User>   ReadUser();
    
    object CheckEmailContains(string email);
}