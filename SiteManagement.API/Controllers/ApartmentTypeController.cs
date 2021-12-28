using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.ApartmentType.Command.CreateApartmentType;
using SiteManagement.Application.ApartmentType.Command.UpdateApartmentType;
using SiteManagement.Application.ApartmentType.Queries.GetAllApartmentTypes;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{

    public class ApartmentTypeController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> CreateApartmentType(CreateApartmentTypeDto apartment)
        {
            return HandleResult(await Mediator.Send(new CreateApartmentTypeHandler.Command { CreateApartmentType = apartment }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateApartmentType([FromBody] UpdateApartmentTypeDto apartment)
        {
            return HandleResult(await Mediator.Send(new UpdateApartmentTypeHandler.Command { UpdateApartmentTypeDto = apartment }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApartmentTypes()
        {
            return HandleResult(await Mediator.Send(new GetAllApartmentTypeHandler.Query()));
        }
    }
}
