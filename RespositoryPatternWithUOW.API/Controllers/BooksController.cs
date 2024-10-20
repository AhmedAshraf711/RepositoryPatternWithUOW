using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;

        public BooksController(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_bookRepository.GetById(id));
        }
        [HttpGet("async")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _bookRepository.GetByIdAsync(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookRepository.GetAll());
        }
        [HttpGet("Name")]
        public IActionResult GetByName(string name)
        {
            var result = _bookRepository.Find(b => b.Title == name, new[] { "Author" });
            return Ok(new {BookId=result.Id,BookName=result.Title,BookAuthor=result.Author.Name});
        }
        [HttpGet("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            
            return Ok(_bookRepository.FindAll(b=>b.Title.Contains(name), new[] {"Author"} ));
        }
        [HttpGet("GetAllByNametakeandskip")]
        public IActionResult GetAllByNametakeandskip(string name,int skip,int take)
        {

            return Ok(_bookRepository.FindAll(b => b.Title.Contains(name),skip,take));
        }
        [HttpGet("GetAllByNamebyorder")]
        public IActionResult GetAllByNamebyorder(string name, int take, int skip)
        {

            return Ok(_bookRepository.FindAll(b=>b.Title.Contains(name),skip,take));
        }

    }
}
