using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Apartment.Command.CreateApartment;
using SiteManagement.Application.Apartment.Command.UpdateApartment;
using SiteManagement.Application.Apartment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{
    
    public class ApartmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateApartment(CreateApartmentDto apartment)
        {
            return HandleResult(await Mediator.Send(new CreateApartmentHandler.Command { CreateApartmentDto = apartment }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartment([FromBody] UpdateApartmentDto apartment)
        {
            return HandleResult(await Mediator.Send(new UpdateApartmentHandler.Command { UpdateApartmentDto = apartment }));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllApartments()
        {
            return HandleResult(await Mediator.Send(new GetApartmentListHandler.Query()));
        }
    }
}
