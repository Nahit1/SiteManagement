using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Person.Command.CreatePerson
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxOffice { get; set; }

        public string Photo { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string OfficePhone { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public int EducationStatus { get; set; }
        public string GraduatedSchool { get; set; }

        public string Job { get; set; }
        public int BloodType { get; set; }
        public string ChronicDisease { get; set; }
        public int Pet { get; set; }
    }
}
