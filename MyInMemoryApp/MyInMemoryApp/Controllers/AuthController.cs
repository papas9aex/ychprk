using Microsoft.AspNetCore.Mvc;
using MyInMemoryApp.Models;

namespace MyInMemoryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;

        public AuthController(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet("users")]
        public ActionResult<List<User>> GetUsers()
        {
            return _dataStore.GetUsers();
        }

        [HttpPost("register")]
        public ActionResult<User> Register(User user)
        {
            _dataStore.AddUser(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(string username, string password)
        {
            var user = _dataStore.Authenticate(username, password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
