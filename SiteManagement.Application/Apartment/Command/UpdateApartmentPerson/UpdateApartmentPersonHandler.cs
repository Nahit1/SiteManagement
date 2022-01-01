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

namespace SiteManagement.Application.Apartment.Command.UpdateApartmentPerson
{
    public class UpdateApartmentPersonHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateApartmentPersonDto UpdateApartmentPersonDto { get; set; }
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
                var apartment = await _context.Apartments.FindAsync(request.UpdateApartmentPersonDto.ApartmentId);
                if (apartment == null) return Result<Unit>.Failure("There is No Apartment");

                var person = await _context.Persons.FindAsync(request.UpdateApartmentPersonDto.PersonId);
                if (person == null) return Result<Unit>.Failure("There is No Person");

                var updatedApartmentPerson = _context.ApartmentPerson.Where(x => x.ApartmentId == request.UpdateApartmentPersonDto.ApartmentId &&
                                                                      x.PersonId == request.UpdateApartmentPersonDto.PersonId &&
                                                                      x.Active).FirstOrDefault();

                
                if (updatedApartmentPerson != null)
                {


                    if (request.UpdateApartmentPersonDto.OwnerShipStatus == 1)
                    {

                        if (updatedApartmentPerson.DateOfExit != DateTime.MinValue)
                        {
                            if (request.UpdateApartmentPersonDto.DateOfExit > updatedApartmentPerson.DateOfEntry)
                                return Result<Unit>.Failure("Çıkış tarihi, giriş tarihinden önce olamaz!");

                            updatedApartmentPerson.Active = false;
                            updatedApartmentPerson.Share = 0;
                            updatedApartmentPerson.DateOfExit = request.UpdateApartmentPersonDto.DateOfExit;
                        }
                        else
                        {
                            var allApartmentPerson = _context.ApartmentPerson.Where(x => x.ApartmentId == request.UpdateApartmentPersonDto.ApartmentId &&
                                                                              x.Active).ToList();

                            if (allApartmentPerson.Count > 0)
                            {

                                var changedShare = allApartmentPerson.Where(x => x.PersonId == updatedApartmentPerson.PersonId).FirstOrDefault();

                                changedShare.Share = request.UpdateApartmentPersonDto.Share;

                                int remainShare = (100 - (int)allApartmentPerson.Sum(x => x.Share));
                                if (remainShare < 0)
                                    return Result<Unit>.Failure("Total share can't be greater than 100");
                            }
                        }

                    }
                    else if (request.UpdateApartmentPersonDto.OwnerShipStatus == 2)
                    {
                        if (updatedApartmentPerson.DateOfExit != DateTime.MinValue)
                        {
                            if (request.UpdateApartmentPersonDto.DateOfExit > updatedApartmentPerson.DateOfEntry)
                                return Result<Unit>.Failure("Çıkış tarihi, giriş tarihinden önce olamaz!");

                            updatedApartmentPerson.Active = false;
                            updatedApartmentPerson.DateOfExit = request.UpdateApartmentPersonDto.DateOfExit;
                        }
                    }

                    updatedApartmentPerson.LastModified = DateTime.Now;
                    updatedApartmentPerson.LastModifiedBy = "UpdatedBySys";
                    updatedApartmentPerson.Apartment = apartment;
                    updatedApartmentPerson.Person = person;
                    _context.Entry(updatedApartmentPerson).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    
                }

                return Result<Unit>.Failure("Problem updating ApartmentPerson");

            }
        }
    }
}
