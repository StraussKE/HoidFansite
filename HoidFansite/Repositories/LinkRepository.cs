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

        static LinkRepository()
        {
            AddDemoLinks();
        }

        public static void AddLink(Link link)
        {
            links.Add(link);
        }

        static void AddDemoLinks()
        {
            Link link = new Link()
            {
                Title = "Coppermind - Hoid",
                Address = "https://coppermind.net/wiki/Hoid"
            };
            AddLink(link);

            link = new Link()
            {
                Title = "Stormlight Archive wiki - Hoid",
                Address = "https://stormlightarchive.fandom.com/wiki/Hoid"
            };
            AddLink(link);

            link = new Link()
            {
                Title = "Mistborn wiki - Hoid",
                Address = "https://mistborn.fandom.com/wiki/Hoid"
            };
            AddLink(link);

            link = new Link()
            {
                Title = "Brandon Sanderson's Website",
                Address = "https://brandonsanderson.com/"
            };
            AddLink(link);
        }
    }


}
