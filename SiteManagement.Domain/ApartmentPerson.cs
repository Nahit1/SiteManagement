using System;
using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Domain
{
    public class ApartmentPerson:BaseEntity
    {

        public int OwnerShipStatus { get; set; }
        public int? Share { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime? DateOfExit { get; set; }

        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
