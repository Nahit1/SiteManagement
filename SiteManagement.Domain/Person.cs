
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain
{
    public class Person:BaseEntity
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string IdentityNumber { get; set; }

        [MaxLength(50)]
        public string TaxOffice { get; set; }

        public string Photo { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string MobilePhone { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string OfficePhone { get; set; }

        [MaxLength(30)]
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public int? EducationStatus { get; set; }

        [MaxLength(100)]
        public string GraduatedSchool { get; set; }

        [MaxLength(50)]
        public string Job { get; set; }
        public int? BloodType { get; set; }
        public string ChronicDisease { get; set; }
        public int? Pet { get; set; }

        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        public ICollection<ApartmentPerson> Apartments { get; set; } = new List<ApartmentPerson>();
    }
}
