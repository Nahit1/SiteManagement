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

namespace SiteManagement.Application.Apartment.Command.UpdateApartment
{
    public class UpdateApartmentHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateApartmentDto UpdateApartmentDto { get; set; }
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
                var apartment = await _context.Apartments.FindAsync(request.UpdateApartmentDto.Id);

                if (apartment != null)
                {
                    apartment.LastModified = DateTime.Now;
                    apartment.LastModifiedBy = "UpdatedBySys";
                    apartment.ParkingPlaceCount = request.UpdateApartmentDto.ParkingPlaceCount;
                    apartment.UsingStatus = request.UpdateApartmentDto.UsingStatus;
                    apartment.UsingType = request.UpdateApartmentDto.UsingType;
                    apartment.ApartmentNo = request.UpdateApartmentDto.ApartmentNo;
                    apartment.ApartmentTypeId = request.UpdateApartmentDto.ApartmentTypeId;
                    apartment.BlockId = request.UpdateApartmentDto.BlockId;
                    apartment.Direction = request.UpdateApartmentDto.Direction;
                    apartment.Floor = request.UpdateApartmentDto.Floor;


                    _context.Entry(apartment).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem updating block");
                }

                return Result<Unit>.Failure("Apartment is not found");
            }
        }
    }
}
