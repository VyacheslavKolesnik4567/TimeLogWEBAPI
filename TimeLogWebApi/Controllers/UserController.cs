using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using TimeLogDataAccess.Entities;
using TimeLogDomain.Interfaces;
using TimeLogWebApi.Models;

namespace TimeLogWebApi.Controllers
{
    public class UserController : ApiController
    {
        IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserViewModel>());

            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(userService.GetAllUsers());
        }
    }
}
