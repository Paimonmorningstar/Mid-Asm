using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Services.Interfaces;
using Common.Enums;
using TestWebAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly TestContext _bookBorrowingRequestContext;
        public BookBorrowingRequestService(TestContext bookBorrowingRequestContext)
        {
            _bookBorrowingRequestContext = bookBorrowingRequestContext;
        }

        public IEntityDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabaseTransaction(_bookBorrowingRequestContext);
        }

        public async Task<BookBorrowingRequest> CreateBookBorrowingRequest (BorrowingRequestModel requestModel, User user)
        {
            if (requestModel == null || requestModel.BookIds == null || requestModel.BookIds.Count == 0) throw new Exception("null");
            using (var transaction = DatabaseTransaction())
            {
                try
                {   
                    var addBookRequest = new BookBorrowingRequest
                    {
                        RequuestedByUser = user,
                        UserId = user.UserId,
                        Status = RequestBookStatusEnum.Waiting,
                        RequestedDate = DateTime.Now,
                    };

                    var newBookRequest = await _bookBorrowingRequestContext.BookBorrowingRequests.AddAsync(addBookRequest);
                    await _bookBorrowingRequestContext.SaveChangesAsync();

                    foreach (var bookId in requestModel.BookIds)
                    {
                        var book = await _bookBorrowingRequestContext.Books.FirstOrDefaultAsync(b => b.BookId == bookId);

                        if (book == null)
                        { //TODO 
                            transaction.RollBack();
                            return null;
                        }
                        var newRequestDetails = await _bookBorrowingRequestContext.BookBorrowingRequestDetailsData.AddAsync(new BookBorrowingRequestDetails
                        {
                            BookBorrowingRequest = addBookRequest,
                            RequestId = addBookRequest.RequestId,
                            Book = book!,
                            StartDate = DateTime.Now,
                        });
                    }
                    await _bookBorrowingRequestContext.SaveChangesAsync();

                    transaction.Commit();
                    return addBookRequest;
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}
