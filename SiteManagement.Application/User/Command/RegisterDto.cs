using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.User.Command
{
    public class RegisterDto:UserLoginDto
    {
        public string Username { get; set; }
        public Guid SiteId { get; set; }
    }
}
