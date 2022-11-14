using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class BookBorrowingRequestDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        public RequestBookDetailStatusEnum Status { get; set; } = RequestBookDetailStatusEnum.Waiting;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        public Book Book { get; set; }
    }
}
