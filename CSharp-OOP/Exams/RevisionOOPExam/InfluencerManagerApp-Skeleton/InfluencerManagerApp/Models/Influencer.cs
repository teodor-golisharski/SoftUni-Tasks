using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private double engagementRate;
        private double income;
        private readonly List<string> participations;

        protected Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            
            Income = 0;
            participations = new List<string>();
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                username = value;
            }
        }

        public int Followers
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                followers = value;
            }
        }

        public double EngagementRate
        {
            get => engagementRate;
            private set
            {
                engagementRate = value;
            }
        }

        public double Income
        {
            get => income;
            private set
            {
                income = value;
            }
        }

        public IReadOnlyCollection<string> Participations => participations;

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            income += amount;
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
