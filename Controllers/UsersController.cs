using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserPortal.Models.Entities;
using UserPortal.DTO;

namespace UserPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.Users);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddEmployee(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Salary = userDto.Salary
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateUserDto employeeDto)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = employeeDto.Name;
            user.Email = employeeDto.Email;
            user.PhoneNumber = employeeDto.PhoneNumber;
            user.Salary = employeeDto.Salary;
            _dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Users.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(employee);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
