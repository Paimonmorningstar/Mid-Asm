using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }

        public DbSet<BookBorrowingRequestDetails> BookBorrowingRequestDetailsData { get; set; }
        public object Category { get; set; }
    }
}
