using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unit_test.Models;
using Unit_test.Services;

namespace Unit_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var user = _userService.GetByIdUser(id);
            if(user== null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add_User([FromBody] Users user)
        {
            _userService.Add(user);
            return CreatedAtAction(nameof(GetId), new { id = user.Id }, user);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Users user)
        {
            
            if (id != user.Id)
            {
                return NotFound();
            }
            _userService.Update(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }


    }
}
