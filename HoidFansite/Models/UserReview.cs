using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HoidFansite.Models
{
    public class UserReview
    {
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter story title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The story cannot be blank")]
        public string Body { get; set; }

        public int Rating { get; set; }
    }
}
