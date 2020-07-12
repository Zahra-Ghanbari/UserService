using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using AutoMapper;
using User.API.Models;
using System.Linq.Expressions;

namespace User.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService iUserService,IMapper mapper)
        {
            _userService = iUserService ?? throw new ArgumentNullException(nameof(iUserService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            if(!ModelState.IsValid)
            {
                BadRequest(ModelState);

            }

            var finalUser = _mapper.Map<Model.User>(user);
            _userService.UserRegistration(finalUser);

            return Ok();

        }
    }
}