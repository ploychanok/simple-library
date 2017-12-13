using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Book ID")]
        public int BookID { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }
        [Display(Name = "Pages")]
        public int Pages { get; set; }
        [Display(Name = "Available")]
        public bool Available { get; set; }
    }
}
