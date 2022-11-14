using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> Get();
        Task<Book?> Get(int id);
        Task InitData();
        Task<BookPagination> GetPaginationAsync(BookQueryModel queryModel);
        public void  DeleteBook(int id);
        public void  CreateBook(Book book);
        public void UpdateBook(Book book);
    }
}
