using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("people2Service")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);
            return NoContent();

        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People() { Id = 1, Name = "Carlos", BirthDate = new DateTime(1976, 12, 14) },
            new People() { Id = 2, Name = "Carmen", BirthDate = new DateTime(1955, 3, 4) },
            new People() { Id = 3, Name = "Karol", BirthDate = new DateTime(2004, 4, 14) },
            new People() { Id = 4, Name = "Miguel", BirthDate = new DateTime(2003, 2, 14) }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }


}
