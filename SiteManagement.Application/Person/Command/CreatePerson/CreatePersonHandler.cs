using AutoMapper;
using MediatR;
using SiteManagement.Application.Core;
using SiteManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Person.Command.CreatePerson
{
    public class CreatePersonHandler
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreatePersonDto CreatePersonDto { get; set; }
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
                var person = _mapper.Map<Domain.Person>(request.CreatePersonDto);

                var site = _context.Sites.Where(x => x.CellPhoneNumber == "55566633322").FirstOrDefault();
                if (site == null) return Result<Unit>.Failure("There is No Site");

                person.Site = site;

                person.Active = true;
                person.Created = DateTime.Now;
                person.CreatedBy = "sistem";
                person.Deleted = false;

                _context.Persons.Add(person);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Person");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
