using Test.Data.Entities;

namespace TestWebAPI.Models.Responses
{
    public class BookResponseModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
