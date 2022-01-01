using MediatR;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Block.Command.CreateBlock
{
    public class CreateBlockHandler
    {
        public class Command: IRequest<Result<CreateBlockResponseDto>>
        {
            public CreateBlockDto CreateBlockDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<CreateBlockResponseDto>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<CreateBlockResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var site = _context.Sites.Where(x => x.CellPhoneNumber == "55566633322").FirstOrDefault();
                if (site == null) return Result<CreateBlockResponseDto>.Failure("There is No Site");
                CreateBlockResponseDto vm = new CreateBlockResponseDto
                {
                    Name = request.CreateBlockDto.Name
                };

                _context.Blocks.Add(new Domain.Block
                {
                    Active = true,
                    Code = request.CreateBlockDto.Code,
                    Created = DateTime.Now,
                    CreatedBy = "Sistem",
                    Deleted = false,
                    Name = request.CreateBlockDto.Name,
                    Site = site
                });

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<CreateBlockResponseDto>.Failure("Failed to create Cash");

                return Result<CreateBlockResponseDto>.Success(vm);
            }
        }
    }
}
