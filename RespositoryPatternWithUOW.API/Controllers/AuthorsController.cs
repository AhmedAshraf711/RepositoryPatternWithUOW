using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorRepository;

        public AuthorsController(IBaseRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public IActionResult GetById(int id) 
        {
            return Ok (_authorRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorRepository.Add(author);
            return Ok(author);
        }
        [HttpPost("addrange")]
        public IActionResult AddRange(IEnumerable<Author> author)
        {
            _authorRepository.AddRange(author);
            return Ok(author);
        }
    }
}
