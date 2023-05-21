using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortenerBackend.Models;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly TestProjectContext _dbContext;

        public UsersController(TestProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            List<User> list = _dbContext.Users.ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        [Route("GetUrls")]
        public IActionResult GetURLs()
        {
            List<Url> list = _dbContext.Urls.ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            UserInfo user = new UserInfo(_dbContext.Users.FirstOrDefault(e => e.Email == email));
            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            foreach(var item in _dbContext.Users)
            {
                if(item.Email.Trim() == model.Email.Trim())
                {
                    if(item.Password.Trim() == model.Password.Trim())
                    {
                        Console.WriteLine("VALIDATED");
                        return Ok();
                    }
                    Console.WriteLine("NOTVALIDATED PASWWORD");
                    return BadRequest("Invalid email or password");
                }
            }
            Console.WriteLine("NOTVALIDATED");
            return BadRequest("Invalid email or password");

        }
    }


}
