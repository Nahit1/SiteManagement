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

namespace SiteManagement.Application.ApartmentType.Command.UpdateApartmentType
{
    public class UpdateApartmentTypeHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateApartmentTypeDto UpdateApartmentTypeDto { get; set; }
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
                var apartmentType = await _context.ApartmentTypes.FindAsync(request.UpdateApartmentTypeDto.Id);

                if(apartmentType != null)
                {
                    apartmentType.LastModified = DateTime.Now;
                    apartmentType.LastModifiedBy = "UpdatedBySys";
                    apartmentType.Name = request.UpdateApartmentTypeDto.Name;
                    apartmentType.NetArea = request.UpdateApartmentTypeDto.NetArea;
                    apartmentType.GrossArea = request.UpdateApartmentTypeDto.GrossArea;
                    apartmentType.Dues = request.UpdateApartmentTypeDto.Dues;

                    _context.Entry(apartmentType).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem updating block");
                }

                return Result<Unit>.Failure("ApartmentType is not found");
            }
        }
    }
}
