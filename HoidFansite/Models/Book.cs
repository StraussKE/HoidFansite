using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoidFansite.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Please enter author's name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter book title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter book summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please enter publication date")]
        public string PublicationDate { get; set; }

        [Required(ErrorMessage = "Please enter book ISBN")]
        public string Isbn { get; set; }
    }
}
