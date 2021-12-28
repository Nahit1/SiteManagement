using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Apartment.Command.UpdateApartment
{
    public class UpdateApartmentDto
    {
        public Guid Id { get; set; }
        public int ApartmentNo { get; set; }
        public int Floor { get; set; }

        public bool UsingStatus { get; set; }
        public int? ParkingPlaceCount { get; set; }

        public int? Direction { get; set; }
        public int UsingType { get; set; }


        public Guid BlockId { get; set; }

        public Guid ApartmentTypeId { get; set; }
    }
}
