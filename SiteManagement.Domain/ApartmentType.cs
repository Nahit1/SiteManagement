using System;

namespace SiteManagement.Domain
{
    public class ApartmentType:BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? GrossArea { get; set; }
        public decimal? NetArea { get; set; }
        public decimal Dues { get; set; }

    }
}
