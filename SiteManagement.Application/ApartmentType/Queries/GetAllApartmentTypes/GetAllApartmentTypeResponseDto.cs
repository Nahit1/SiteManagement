using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.ApartmentType.Queries.GetAllApartmentTypes
{
    public class GetAllApartmentTypeResponseDto
    {
        public string Name { get; set; }
        public decimal GrossArea { get; set; }
        public decimal NetArea { get; set; }
        public decimal Dues { get; set; }
    }
}
