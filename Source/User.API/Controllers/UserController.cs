using System;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using AutoMapper;
using UserAPI.Models;
using Microsoft.Extensions.Logging;
using Entity;

namespace UserAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService iUserService, IMapper mapper, ILogger<UserController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = iUserService ?? throw new ArgumentNullException(nameof(iUserService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {                   
                    _logger.LogInformation
                        ("server is unable to process the request sent by the client due to invalid request");
                    BadRequest(ModelState);
                }

                var finalUser = _mapper.Map<User>(user);
                _userService.UserRegistration(finalUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception happens when add a user",ex);
                return StatusCode(500,"A problem happend while received your request.");

            }
            return Ok();
        }
    }
}