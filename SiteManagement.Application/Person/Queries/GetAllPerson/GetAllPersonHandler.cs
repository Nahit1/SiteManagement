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

namespace SiteManagement.Application.Person.Queries.GetAllPerson
{
    public class GetAllPersonHandler
    {
        public class Query : IRequest<Result<List<GetAllPersonResponseDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetAllPersonResponseDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GetAllPersonResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = await _context.Persons.AsNoTracking()
                    .ProjectTo<GetAllPersonResponseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<GetAllPersonResponseDto>>.Success(person);
            }
        }
    }
}
