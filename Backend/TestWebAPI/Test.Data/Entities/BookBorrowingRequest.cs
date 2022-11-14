using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class BookBorrowingRequest 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public Guid UserId { get; set; }
        public User RequuestedByUser { get; set; }
        public DateTime RequestedDate { get; set; }
        public RequestBookStatusEnum Status { get; set; }
        public ICollection<BookBorrowingRequestDetails>? BookRequestDetails { get; set; }
    }
}
