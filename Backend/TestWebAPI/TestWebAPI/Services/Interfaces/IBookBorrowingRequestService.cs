using Test.Data.Entities;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        Task<BookBorrowingRequest> CreateBookBorrowingRequest(BorrowingRequestModel requestModel, User user);

        IEntityDatabaseTransaction DatabaseTransaction();
    }
}
