using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoidFansite.Models
{
    public class BookRepository
    {
        private static List<Book> books = new List<Book>();

        public static List<Book> Books
        {
            get
            {
                return books;
            }
        }

        public static void AddResponse(Book book)
        {
            books.Add(book);
        }
    }
}
