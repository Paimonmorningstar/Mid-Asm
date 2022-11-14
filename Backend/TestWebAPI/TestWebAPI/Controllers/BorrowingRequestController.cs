using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class BorrowingRequestController : ControllerBase
    {
        private readonly IBookBorrowingRequestService _bookBorrowingRequestService;
        private readonly IUsersService _usersService;

        public BorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestServicersService, IUsersService usersService)
        {
            _bookBorrowingRequestService = bookBorrowingRequestServicersService;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.NormalUser)]
        [HttpPost("bookRequest")]
        public async Task<IActionResult> CreateBookBorrowingRequestAsync([FromBody]BorrowingRequestModel requestModel)
        {
            var userId = this.GetCurrentLoginUserId();
            if (userId != null)
            {
                var user = await _usersService.GetUsersById(userId.Value);

                if (user != null)
                {
                    var bookBorrowingRequest = _bookBorrowingRequestService.CreateBookBorrowingRequest(requestModel, user);

                    return bookBorrowingRequest != null ? Ok(bookBorrowingRequest) : BadRequest();
                }
                else 
                {
                return BadRequest();
                }
            }
            else
                return BadRequest();
        }
    }
}