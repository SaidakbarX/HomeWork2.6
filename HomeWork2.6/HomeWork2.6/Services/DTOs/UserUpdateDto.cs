using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._6.Services.DTOs;

public class UserUpdateDto : BaseUserDto
{
    public Guid Id  { get; set; }
    public  string  Password { get; set; }
}
