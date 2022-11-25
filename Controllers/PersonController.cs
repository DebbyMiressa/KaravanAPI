using Karavan.Data;
using Karavan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _Person;
        public PersonController(IPerson Person)
        {
            _Person = Person;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Person _person)
        {
            if (_person == null)
            {
                return BadRequest();
            }
            POJO model = await _Person.SavePerson(_person);
            if (model == null)
            {
               return NotFound();
            }
            return Ok(model);
        }

        [HttpGet ("{phoneNumber}/{password}")]
        public async Task<IActionResult> Login(string? phoneNumber, string? password)
        {
            if (phoneNumber == null || password == null)
            {
                return BadRequest();
            }
            Person model = await _Person.GetPerson(phoneNumber, password);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IQueryable<Person> model = _Person.GetUsers;
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            POJO model = await _Person.DeleteUser(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok();
        }
        */
    }
}
