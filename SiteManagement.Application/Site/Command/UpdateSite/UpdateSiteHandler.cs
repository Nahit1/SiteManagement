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

namespace SiteManagement.Application.Site.Command.UpdateSite
{
    public class UpdateSiteHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateSiteDto UpdateSiteDto { get; set; }
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
                var site = await _context.Sites.FindAsync(request.UpdateSiteDto.Id);

                if (site != null)
                {
                    site.LastModified = DateTime.Now;
                    site.LastModifiedBy = "UpdatedBySys";
                    site.Address = request.UpdateSiteDto.Address;
                    site.ApartmentCount = request.UpdateSiteDto.ApartmentCount;
                    site.BlockCount = request.UpdateSiteDto.BlockCount;
                    site.CellPhoneNumber = request.UpdateSiteDto.CellPhoneNumber;
                    site.District = request.UpdateSiteDto.District;
                    site.PhoneNumber = request.UpdateSiteDto.PhoneNumber;
                    site.Province = request.UpdateSiteDto.Province;
                    site.SiteName = request.UpdateSiteDto.SiteName;

                    _context.Entry(site).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem updating site");
                }

                return Result<Unit>.Failure("Site is not found");
            }
        }
    }
}
