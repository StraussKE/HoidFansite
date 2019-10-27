using System.ComponentModel.DataAnnotations;

namespace HoidFansite.Models
{
    public class UserReview
    {
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter review title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The review cannot be blank")]
        public string Body { get; set; }

        public int Rating { get; set; }
    }
}
