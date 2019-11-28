using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class BookRepository
    {
        private static List<Book> books = new List<Book>();

        public static List<Book> Books { get { return books; } }

        static BookRepository()
        {
            AddDemoBooks();
        }

        public static void AddBook(Book book)
        {
            books.Add(book);
        }

        static void AddDemoBooks()
        {
            Book book = new Book()
            {
                Author = "Brandon Sanderson",
                Title = "The Way of Kings",
                PublicationDate = new DateTime(2010, 8, 31),
                Isbn = "ISBN-13: 978 - 0765365279 ",
                Series = "The Stormlight Archives",
                Summary = "Roshar is a world of stone and storms. Uncanny tempests of incredible power sweep across the rocky " +
                          "terrain so frequently that they have shaped ecology and civilization alike.Animals hide in shells, " +
                          "trees pull in branches, and grass retracts into the soilless ground.Cities are built only where the " +
                          "topography offers shelter.\n\n" +
                          "It has been centuries since the fall of the ten consecrated orders known as the Knights Radiant, but " +
                          "their Shardblades and Shardplate remain: mystical swords and suits of armor that transform ordinary " +
                          "men into near - invincible warriors.Men trade kingdoms for Shardblades.Wars were fought for them, and " +
                          "won by them.\n\n" +
                          "One such war rages on a ruined landscape called the Shattered Plains.There, Kaladin, who traded his " +
                          "medical apprenticeship for a spear to protect his little brother, has been reduced to slavery.In a war " +
                          "that makes no sense, where ten armies fight separately against a single foe, he struggles to save his " +
                          "men and to fathom the leaders who consider them expendable.\n\n" +
                          "Brightlord Dalinar Kholin commands one of those other armies.Like his brother, the late king, he is " +
                          "fascinated by an ancient text called The Way of Kings.Troubled by over - powering visions of ancient " +
                          "times and the Knights Radiant, he has begun to doubt his own sanity.\n\n" +
                          "Across the ocean, an untried young woman named Shallan seeks to train under an eminent scholar and " +
                          "notorious heretic, Dalinar's niece, Jasnah. Though she genuinely loves learning, Shallan's motives are " +
                          "less than pure. As she plans a daring theft, her research for Jasnah hints at secrets of the Knights " +
                          "Radiant and the true cause of the war.\n",
                WheresHoid = "Throughout the Stormlight Archives Hoid is very prominent. He is initially introduced to us under " +
                             "the guise of The King's Wit, or Wit for short."
            };
            books.Add(book);

            book = new Book()
            {
                Author = "Brandon Sanderson",
                Title = "Elantris",
                PublicationDate = new DateTime(2005, 4, 21),
                Isbn = "ISBN-10: 0765311771",
                Series = "Elantris",
                Summary = "Elantris was beautiful, once.  It was called the city of the gods: a place of power, radiance, and magic. " +
                          "Visitors say that the very stones glowed with an inner light, and that the city contained wondrous arcane " +
                          "marvels. At night Elantris shone like a great silvery fire, visible even from a great distance.\n" +
                          "Yet, as magnificent as Elantris had been, its inhabitants had been more so.Their hair a brilliant white, " +
                          "their skin an almost metallic silver, the Elantrians seemed to shine like the city itself.Legend claimed " +
                          "that they were immortal, or at least nearly so.Their bodies healed quickly, and they were blessed with " +
                          "great strength, insight, and speed.They could perform magics with a bare wave of the hand; men visited " +
                          "Elantris from all across Opelon to receive Elantrian healings, food, or wisdom. They were divinities.\n" +
                          "And anyone could become one.\n" +
                          "The Shaod, it was called.  The Transformation.  It struck randomly-- usually at night, during the " +
                          "mysterious hours when life slowed to rest.The Shaod could take beggar, craftsman, nobleman, or warrior. " +
                          "When it came, the fortunate person's life ended and began anew; he would discard his old, mundane " +
                          "existence and move to Elantris.  Elantris, where he could live in bliss, rule in wisdom, and be worshipped " +
                          "for eternity.\n" +
                          "Eternity ended ten years ago.",
                WheresHoid = "Hoid is the bandaged begger, helping smuggle weapons into Elantris."
            };
            books.Add(book);
        }
    }
}
