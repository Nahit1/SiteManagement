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

namespace SiteManagement.Application.Apartment.Queries
{
    public class GetApartmentListHandler
    {
        public class Query : IRequest<Result<List<GetApartmentListResponseDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetApartmentListResponseDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GetApartmentListResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var apartment = await _context.Apartments.Include(a=>a.Persons)
                    .ProjectTo<GetApartmentListResponseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<GetApartmentListResponseDto>>.Success(apartment);
            }
        }
    }
}
