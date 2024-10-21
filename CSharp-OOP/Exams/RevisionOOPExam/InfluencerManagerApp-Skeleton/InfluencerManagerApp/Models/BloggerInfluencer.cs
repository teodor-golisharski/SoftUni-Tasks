using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double engagementRate = 2;
        private const double factor = 0.2;

        public BloggerInfluencer(string username, int followers) : base(username, followers, engagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
