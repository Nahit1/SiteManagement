using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Person.Command.CreatePerson;
using SiteManagement.Application.Person.Command.UpdatePerson;
using SiteManagement.Application.Person.Queries.GetAllPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{
    
    public class PersonController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonDto person)
        {
            return HandleResult(await Mediator.Send(new CreatePersonHandler.Command { CreatePersonDto = person }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDto person)
        {
            return HandleResult(await Mediator.Send(new UpdatePersonHandler.Command { UpdatePersonDto = person }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            return HandleResult(await Mediator.Send(new GetAllPersonHandler.Query()));
        }
    }
}
