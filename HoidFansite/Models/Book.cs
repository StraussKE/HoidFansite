using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoidFansite.Models
{
    public class Book
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Isbn { get; set; }

        public string WheresHoid { get; set; }

        public string Series { get; set; }
    }
}
