using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain
{
    public class User:IdentityUser
    {
        public ICollection<Site> Sites { get; set; } = new List<Site>();
    }
}
