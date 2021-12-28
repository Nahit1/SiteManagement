using AutoMapper;
using MediatR;
using SiteManagement.Application.Core;
using SiteManagement.Domain;
using SiteManagement.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Site.Command.CreateSite
{
    public class CreateSiteHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateSiteDto CreateSiteDto { get; set; }
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
               
                var site = _mapper.Map<Domain.Site>(request.CreateSiteDto);

                site.Active = true;
                site.Created = DateTime.Now;
                site.CreatedBy = "sistem";
                site.Deleted = false;

                _context.Sites.Add(site);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Site");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
