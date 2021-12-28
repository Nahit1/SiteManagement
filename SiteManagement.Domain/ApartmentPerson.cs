using System;

namespace SiteManagement.Domain
{
    public class ApartmentPerson:BaseEntity
    {
        public Guid Id { get; set; }
        public int OwnerShipStatus { get; set; }
        public int Share { get; set; }

        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
