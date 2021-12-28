using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.ApartmentType.Command.CreateApartmentType
{
    public class CreateApartmentTypeDto
    {
        public string Name { get; set; }
        public decimal GrossArea { get; set; }
        public decimal NetArea { get; set; }
        public decimal Dues { get; set; }
    }
}
