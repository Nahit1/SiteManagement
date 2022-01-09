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

namespace SiteManagement.Application.Site.Queries.GetAllSites
{
    public class GetAllSiteHandler
    {
        public class Query : IRequest<Result<List<GetAllSiteResponseDto>>> 
        {
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetAllSiteResponseDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GetAllSiteResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {


                var sites = await _context.Sites.Where(x=>x.Users.Any(u=>u.Id==request.UserId)).AsNoTracking()
                    .ProjectTo<GetAllSiteResponseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<GetAllSiteResponseDto>>.Success(sites);
            }
        }
    }
}
