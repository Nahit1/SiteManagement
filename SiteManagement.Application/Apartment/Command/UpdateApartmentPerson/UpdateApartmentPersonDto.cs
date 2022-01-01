using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Apartment.Command.UpdateApartmentPerson
{
    public class UpdateApartmentPersonDto
    {
        public Guid PersonId { get; set; }
        public Guid ApartmentId { get; set; }
        public int OwnerShipStatus { get; set; }
        public int Share { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime DateOfExit { get; set; }
    }
}
