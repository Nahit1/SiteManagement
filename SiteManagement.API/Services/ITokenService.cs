using SiteManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
