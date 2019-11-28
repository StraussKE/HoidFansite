using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class ReviewRepository
    {
        private static List<UserReview> userReviews = new List<UserReview>();

        public static List<UserReview> Reviews
        {
            get
            {
                return userReviews;
            }
        }

        public static void AddReview(UserReview review)
        {
            userReviews.Add(review);
        }
    }
}