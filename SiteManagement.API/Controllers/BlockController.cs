using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Block.Command.CreateBlock;
using SiteManagement.Application.Block.Command.UpdateBlock;
using SiteManagement.Application.Block.Queries.GetAllBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{
    
    public class BlockController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBlock([FromBody] CreateBlockDto block)
        {
            return HandleResult(await Mediator.Send(new CreateBlockHandler.Command { CreateBlockDto = block }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlock([FromBody] UpdateBlockDto block)
        {
            return HandleResult(await Mediator.Send(new UpdateBlockHandler.Command { UpdateBlockDto = block }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlocks()
        {
            return HandleResult(await Mediator.Send(new GetAllBlocksHandler.Query()));
        }
    }
}
