using Common.System;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Models
{
    public class BookPagination
    {
        public List<Book> Books { get; set; }
        public int TotalBooksCount { get; set; }
        public int TotalPage { get; set; }
        public BookQueryModel QueryModel { get; set; }
    }
}
