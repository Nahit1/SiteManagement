using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Block.Command.UpdateBlock
{
    public class UpdateBlockHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateBlockDto UpdateBlockDto { get; set; }
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
                var block = await _context.Blocks.FindAsync(request.UpdateBlockDto.Id);

                if(block != null)
                {
                    block.Name = request.UpdateBlockDto.Name;
                    block.Code = request.UpdateBlockDto.Code;
                    block.LastModified = DateTime.Now;
                    block.LastModifiedBy = "UpdatedBySys";
                    _context.Entry(block).State = EntityState.Modified;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem updating block");
                }

                return Result<Unit>.Failure("Block is not found");
            }
        }
    }

}
