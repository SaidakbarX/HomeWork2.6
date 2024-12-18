using HomeWork2._6.Services;
using HomeWork2._6.Services.DTOs;

namespace HomeWork2._6
{
    internal class Program
    {
        static void Main(string[] args)
        {  IUserServices services = new UserServices();
            UserCreatDto dto = new UserCreatDto()
            {
                FirstName = "Ali",
                LastName = "Vali",
                Password = "4545",
                Age = 24,
                Email = "Ali@gmail.com",
            }; 
            UserCreatDto dto1 = new UserCreatDto()
            {
                FirstName = "Azamat",
                LastName = "Mahkamov",
                Password = "6969",
                Age = 24,
                Email = "Shaxriyor@gmail.com",
            };
            services.AddUser(dto1);
            services.AddUser(dto);
           
        }
    }
}
