using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public interface IReviewRepository
    {
        List<UserReview> Reviews { get; }

        void AddReview(UserReview review);

        List<UserReview> GetReviewsByStory(int ID);
    }
}
