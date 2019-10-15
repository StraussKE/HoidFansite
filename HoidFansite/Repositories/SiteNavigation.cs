using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoidFansite.Models //Will probably have to modify this namespace later
{
    public class SiteNavigation
    {
        private static List<NavPage> pages = new List<NavPage>();

        public static List<NavPage> NavPages
        {
            get
            {
                return pages;
            }
        }

        static SiteNavigation()
        {
            GenerateNavList();
        }

        public static void AddNavPage(NavPage page)
        {
            pages.Add(page);
        }

        static void GenerateNavList()
        {
            NavPage page = new NavPage()
            {
                Title = "Home",
                Address = "Index"
            };
            AddNavPage(page);

            page = new NavPage()
            {
                Title = "Write Fantfiction",
                Address = "StoryForm"
            };
            AddNavPage(page);

            page = new NavPage()
            {
                Title = "Read Fantfiction",
                Address = "StoryList"
            };
            AddNavPage(page);

            page = new NavPage()
            {
                Title = "History",
                Address = "History"
            };
            AddNavPage(page);

            page = new NavPage()
            {
                Title = "Books",
                Address = "/Sources/BookList"
            };
            AddNavPage(page);

            page = new NavPage()
            {
                Title = "External Links",
                Address = "/Sources/LinkList"
            };
            AddNavPage(page);
        }
    }
}
