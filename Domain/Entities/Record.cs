using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Domain.Entities
{
    public class Record
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Record ID")]
        public int RecordID { get; set; }
        [Display(Name = "Book ID")]
        public string BookID { get; set; }
        [Display(Name = "Title")]
        public string BookTitle { get; set; }
        [Display(Name = "Member ID")]
        public string MemberID { get; set; }
        [Display(Name = "Member First Name")]
        public string MemberFirstName { get; set; }
        [Display(Name = "Member Last Name")]
        public string MemberLastName { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
