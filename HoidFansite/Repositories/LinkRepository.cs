using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoidFansite.Models
{
    public class LinkRepository
    {
        private static List<Link> links = new List<Link>();

        public static List<Link> Links
        {
            get
            {
                return links;
            }
        }

        public static void AddResponse(Link link)
        {
            links.Add(link);
        }
    }
}
