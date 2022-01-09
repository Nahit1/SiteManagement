using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteManagement.API.DTOs;
using SiteManagement.API.Services;
using SiteManagement.Application.Site.Queries.GetAllSites;
using SiteManagement.Application.Site.Queries.GetSite;
using SiteManagement.Application.User.Command;
using SiteManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.API.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, IMediator mediator, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _mediator = mediator;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.Users.Where(e => e.Email == userLoginDto.Email).Include(x => x.Sites).FirstOrDefaultAsync();
            if (user == null || !await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
                return Unauthorized();

            var site = user.Sites.FirstOrDefault();

            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user),
                SiteId = site.Id,
                SiteName = site.SiteName
            };
            

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var site = await _mediator.Send(new GetSiteHandler.Query { Id = registerDto.SiteId });


            var user = new User { UserName = registerDto.Username, Email = registerDto.Email };

            user.Sites.Add(site.Value);

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            return StatusCode(201);
        }


        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDto>> CurrentUser()
        {
            var user = _userManager.Users.Where(e => e.UserName == User.Identity.Name)
                .Include(x => x.Sites)
                .FirstOrDefaultAsync();

            var site = user.Result.Sites.FirstOrDefault();

            return new UserDto
            {
                UserId = user.Result.Id,
                Email = user.Result.Email,
                Token = await _tokenService.GenerateToken(user.Result),
                SiteId = site.Id,
                SiteName = site.SiteName
            };
        }
    }
}
