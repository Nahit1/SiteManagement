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

namespace SiteManagement.Application.Site.Queries.GetSite
{
    public class GetSiteHandler
    {
        public class Query : IRequest<Result<Domain.Site>> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Domain.Site>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<Domain.Site>> Handle(Query request, CancellationToken cancellationToken)
            {
                var site = await _context.Sites.FindAsync(request.Id);

                if(site == null)
                    return Result<Domain.Site>.Failure("Site Bulunamadı");

                return Result<Domain.Site>.Success(site);
            }
        }
    }
}
