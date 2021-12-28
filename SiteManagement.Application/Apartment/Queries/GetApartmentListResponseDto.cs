using SiteManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Apartment.Queries
{
    public class GetApartmentListResponseDto
    {
        public int ApartmentNo { get; set; }
        public int Floor { get; set; }
        public bool UsingStatus { get; set; }
        public int ParkingPlaceCount { get; set; }
        public int?Direction { get; set; }
        public int UsingType { get; set; }
        public string Block { get; set; }
        public string ApartmentType { get; set; }

        public ICollection<ApartmentPerson> Persons { get; set; }
    }
}
