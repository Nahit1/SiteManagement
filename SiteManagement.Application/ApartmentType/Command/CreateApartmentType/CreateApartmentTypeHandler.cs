using AutoMapper;
using MediatR;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace SiteManagement.Application.ApartmentType.Command.CreateApartmentType
{
    public class CreateApartmentTypeHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateApartmentTypeDto CreateApartmentType { get; set; }
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
                var apartmentType = _mapper.Map<Domain.ApartmentType>(request.CreateApartmentType);

                apartmentType.Active = true;
                apartmentType.Created = DateTime.Now;
                apartmentType.CreatedBy = "sistem";
                apartmentType.Deleted = false;

                _context.ApartmentTypes.Add(apartmentType);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create ApartmentType");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
