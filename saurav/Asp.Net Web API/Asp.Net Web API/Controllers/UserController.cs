using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Web_API.Data;
using Asp.Net_Web_API.Interface;
using Asp.Net_Web_API.model;
using Asp.Net_Web_API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _user;
        //private readonly DataDbContext _dbContext;

        public UserController(IUser user, IMapper mapper)
        {
            _mapper = mapper;
            _user = user;
            //_dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = _user.GetUser();
            var users = user.Result.ToList();
            UserDto userList = _mapper.Map<UserDto>(users);
             return Ok(userList);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserData(User userDATA)
        {
            try
            {
                if (userDATA != null)
                {
                    var objResponse = _user.SaveUser(userDATA);
                    if (objResponse.Result != null)
                        return Ok(objResponse.Result);
                    else
                        return NotFound(new { message = "Sorry, Could not Insert Data!" });
                }
                else{
                    return NotFound(new { message = "Please Fill Data!" });
                 }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message, error = ex.StackTrace});
            }
        }
    }
}