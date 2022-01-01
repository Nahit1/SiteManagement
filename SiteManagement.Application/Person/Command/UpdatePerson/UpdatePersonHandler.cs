using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Person.Command.UpdatePerson
{
    public class UpdatePersonHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdatePersonDto UpdatePersonDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var person = await _context.Persons.FindAsync(request.UpdatePersonDto.Id);

                if (person != null)
                {
                    person.LastModified = DateTime.Now;
                    person.LastModifiedBy = "UpdatedBySys";
                    person.BirthDate = request.UpdatePersonDto.BirthDate;
                    person.BloodType = request.UpdatePersonDto.BloodType;
                    person.ChronicDisease = request.UpdatePersonDto.ChronicDisease;
                    person.EducationStatus = request.UpdatePersonDto.EducationStatus;
                    person.Email = request.UpdatePersonDto.Email;
                    person.Gender = request.UpdatePersonDto.Gender;
                    person.GraduatedSchool = request.UpdatePersonDto.GraduatedSchool;
                    person.IdentityNumber = request.UpdatePersonDto.IdentityNumber;
                    person.Job = request.UpdatePersonDto.Job;
                    person.MobilePhone = request.UpdatePersonDto.MobilePhone;
                    person.Name = request.UpdatePersonDto.Name;
                    person.Nationality = request.UpdatePersonDto.Nationality;
                    person.OfficePhone = request.UpdatePersonDto.OfficePhone;
                    person.Pet = request.UpdatePersonDto.Pet;
                    person.Phone = request.UpdatePersonDto.Phone;
                    person.Photo = request.UpdatePersonDto.Photo;
                    person.TaxOffice = request.UpdatePersonDto.TaxOffice;


                    _context.Entry(person).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem updating person");
                }

                return Result<Unit>.Failure("Person is not found");
            }
        }
    }
}
