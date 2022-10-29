using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SwiggyApp.Models;

namespace SwiggyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        public readonly IConfiguration _config;
        public readonly UserContext _context;
        public UserController(IConfiguration config,UserContext context)
        {
            _config = config;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if(_context.Users.Where(u=>u.Email==user.Email).FirstOrDefault()!=null)
            {
                return Ok("Already Exist");
            }
          user.MemberSince=DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = _context.Users.Where(u => 
            u.Email == user.Email && u.Pwd == user.PWd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok("Success");
            }
            else { return Ok("Failure"); }
           

        }

    }
}
