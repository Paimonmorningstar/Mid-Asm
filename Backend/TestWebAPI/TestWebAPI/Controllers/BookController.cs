using System.Net;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private int id;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public async Task<ActionResult> Index()
        {
            return Ok("Test");
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("Getbook")]
        public async Task<ActionResult> GetBook()
        {
            var result = await _bookService.Get();
            return Ok(result);
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("book/detail/{GetbookId}")]
        public async Task<ActionResult> GetBookById(int bookId)
        {
            var result = await _bookService.Get(bookId);
            return Ok(result);
        }


        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("book/{bookId}")]
        public async Task<ActionResult> GetBookQueryAsync(int pageNumber, int pageSize,
            string? name, int? categoryId, BookSortEnum? sortOption)
        {
            var queryModel = new BookQueryModel
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Name = name,
                CategoryID = categoryId,
                SortOption = sortOption
            };

            var result = await _bookService.GetPaginationAsync(queryModel);
            return Ok(result);

        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpDelete("book/{bookId}")]
        public HttpStatusCode DeleteBook(int id)
        {
         _bookService.DeleteBook(id);
         return HttpStatusCode.OK;
            
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost("book/CreateBook")]
        public HttpStatusCode CreateBook (Book book)
        {
            _bookService.CreateBook(book);
            return HttpStatusCode.OK;
        }


        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPut("book/{bookId}")]
        public HttpStatusCode UpdateBook( Book book )
        {
            _bookService.UpdateBook(book);
            return HttpStatusCode.OK;
        }
    }
}
