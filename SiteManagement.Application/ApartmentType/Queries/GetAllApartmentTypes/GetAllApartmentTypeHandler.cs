using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace SiteManagement.Application.ApartmentType.Queries.GetAllApartmentTypes
{
    public class GetAllApartmentTypeHandler
    {
        public class Query : IRequest<Result<List<GetAllApartmentTypeResponseDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetAllApartmentTypeResponseDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GetAllApartmentTypeResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var apartmentTypes = await _context.ApartmentTypes
                    .ProjectTo<GetAllApartmentTypeResponseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return Result<List<GetAllApartmentTypeResponseDto>>.Success(apartmentTypes);
            }
        }
    }
}
