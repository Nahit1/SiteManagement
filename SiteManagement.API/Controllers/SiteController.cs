using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Site.Command.CreateSite;
using SiteManagement.Application.Site.Command.UpdateSite;
using SiteManagement.Application.Site.Queries.GetAllSites;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{

    public class SiteController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSite(CreateSiteDto createSiteDto)
        {
            return HandleResult(await Mediator.Send(new CreateSiteHandler.Command { CreateSiteDto = createSiteDto }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSite([FromBody] UpdateSiteDto site)
        {
            return HandleResult(await Mediator.Send(new UpdateSiteHandler.Command { UpdateSiteDto = site  }));
        }


        [Authorize]
        [HttpGet("GetAllSites")]
        public async Task<IActionResult> GetAllSites(string userId)
        {
            return HandleResult(await Mediator.Send(new GetAllSiteHandler.Query { UserId = userId }));
        }
    }
}
