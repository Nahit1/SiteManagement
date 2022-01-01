using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Apartment.Command.CreateApartmentPerson;
using SiteManagement.Application.Apartment.Command.UpdateApartmentPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{
    
    public class ApartmentPersonController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateApartmentPerson(CreateApartmentPersonDto apartment)
        {
            return HandleResult(await Mediator.Send(new CreateApartmentPersonHandler.Command { CreateApartmentPersonDto = apartment }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartmentPerson([FromBody] UpdateApartmentPersonDto apartment)
        {
            return HandleResult(await Mediator.Send(new UpdateApartmentPersonHandler.Command { UpdateApartmentPersonDto = apartment }));
        }
    }
}
