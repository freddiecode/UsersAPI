using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsersAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public static List<User> UserList = new List<User>();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return UserList;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = UserList.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return new OkObjectResult(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserList.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User updateUser)
        {
            if (updateUser == null)
            {
                return BadRequest();
            }

            var user = UserList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Id = id;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.DateTime = DateTime.Now;

            return new OkResult();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = UserList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            UserList.Remove(user);

            return new OkResult();
        }
    }
}
