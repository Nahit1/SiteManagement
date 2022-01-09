using SiteManagement.Application.Site.Queries.GetAllSites;
using SiteManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public Guid SiteId { get; set; }
        public string SiteName { get; set; }
    }
}
