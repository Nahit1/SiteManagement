using AutoMapper;
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

namespace SiteManagement.Application.Apartment.Command.CreateApartmentPerson
{
    public class CreateApartmentPersonHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateApartmentPersonDto CreateApartmentPersonDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var apartment = await _context.Apartments.FindAsync(request.CreateApartmentPersonDto.ApartmentId);
                if (apartment == null) return Result<Unit>.Failure("There is No Apartment");

                var person = await _context.Persons.FindAsync(request.CreateApartmentPersonDto.PersonId);
                if (person == null) return Result<Unit>.Failure("There is No Person");

                if (request.CreateApartmentPersonDto.DateOfEntry == DateTime.MinValue)
                    return Result<Unit>.Failure("There is No DateOfEntry");

                if (request.CreateApartmentPersonDto.Share > 100)
                    return Result<Unit>.Failure("Share can't be greater than 100");

                var personExist = await _context.ApartmentPerson.Where(x => x.ApartmentId == request.CreateApartmentPersonDto.ApartmentId &&
                                                                          x.Active).ToListAsync();
                if (request.CreateApartmentPersonDto.OwnerShipStatus == 1)
                {

                    if (personExist.Count > 0)
                    {
                        int existShare = (int)personExist.Sum(x => x.Share);
                        int remainShare = 100 - existShare;

                        if (remainShare < request.CreateApartmentPersonDto.Share)
                            return Result<Unit>.Failure("Total share can't be greater than 100");
                    }

                }
                else if(request.CreateApartmentPersonDto.OwnerShipStatus == 2)
                {
                    var existOwner = personExist.Where(x => x.OwnerShipStatus == 1 && x.Active).ToList();
                    if(existOwner.Count == 0)
                        return Result<Unit>.Failure("Önce ev sahibi ekleyiniz");

                    var existTenant = personExist.Where(x => x.OwnerShipStatus == 2 && x.Active).FirstOrDefault();
                    if(existTenant != null)
                        return Result<Unit>.Failure("Dairede kiracı bulunuyor.");
                    var existTenantDate = await _context.ApartmentPerson.Where(x => x.OwnerShipStatus == 2).ToListAsync();

                    foreach (var item in existTenantDate)
                    {
                        if(item.DateOfExit > request.CreateApartmentPersonDto.DateOfEntry)
                            return Result<Unit>.Failure("Seçtiğiniz tarihte geçmişte kiracı oturuyor.");
                    }

                }

                var apartmentPerson = _mapper.Map<Domain.ApartmentPerson>(request.CreateApartmentPersonDto);
                apartmentPerson.Active = true;
                apartmentPerson.Created = DateTime.Now;
                apartmentPerson.CreatedBy = "sistem";
                apartmentPerson.Deleted = false;
                apartmentPerson.Apartment = apartment;
                apartmentPerson.Person = person;

                _context.ApartmentPerson.Add(apartmentPerson);

                var result = await _context.SaveChangesAsync() > 0;

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
