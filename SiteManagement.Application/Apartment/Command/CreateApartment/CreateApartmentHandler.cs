using AutoMapper;
using MediatR;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Apartment.Command.CreateApartment
{
    public class CreateApartmentHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateApartmentDto CreateApartmentDto { get; set; }
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
                var block = await _context.Blocks.FindAsync(request.CreateApartmentDto.BlockId);

                if(block == null) return Result<Unit>.Failure("There is No Block");

                var apartmentType = await _context.ApartmentTypes.FindAsync(request.CreateApartmentDto.ApartmentTypeId);

                if (apartmentType == null) return Result<Unit>.Failure("There is No ApartmentType");

                var apartment = _mapper.Map<Domain.Apartment>(request.CreateApartmentDto);

                apartment.Active = true;
                apartment.Created = DateTime.Now;
                apartment.CreatedBy = "sistem";
                apartment.Deleted = false;
                apartment.ApartmentType = apartmentType;
                apartment.Block = block;

                _context.Apartments.Add(apartment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Apartment");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
