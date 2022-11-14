using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.Models.Requests
{
    public class BorrowingRequestModel
    {
        [Required]
        public List<int>? BookIds { get; set; }
    }
}
