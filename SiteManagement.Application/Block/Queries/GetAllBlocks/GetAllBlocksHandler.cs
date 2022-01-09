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

namespace SiteManagement.Application.Block.Queries.GetAllBlocks
{
    public class GetAllBlocksHandler
    {
        public class Query : IRequest<Result<List<GetAllBlocksResponseDto>>> 
        {
            public Guid SiteId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetAllBlocksResponseDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GetAllBlocksResponseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var blocks = await _context.Blocks.Where(x=>x.SiteId == request.SiteId)
                    .ProjectTo<GetAllBlocksResponseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return Result<List<GetAllBlocksResponseDto>>.Success(blocks);
            }
        }
    }
}
