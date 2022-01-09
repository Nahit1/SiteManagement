using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain
{
    public class Site:BaseEntity
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public int? BlockCount { get; set; }
        public int? ApartmentCount { get; set; }


        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<Block> Blocks { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
