using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance 
        {
            get { return this.endurance; }
            private set 
            {
                if(StatValidation(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidStatMessage, "Endurance"));
                }
                this.endurance = value; 
            }
        }
        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (StatValidation(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidStatMessage, "Sprint"));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (StatValidation(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidStatMessage, "Dribble"));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (StatValidation(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidStatMessage, "Passing"));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (StatValidation(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidStatMessage, "Shooting"));
                }
                this.shooting = value;
            }
        }

        public double Average 
        { 
            get 
            { 
                return Math.Round((double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5); 
            } 
        }
        private bool StatValidation(int value) => value < 0 || value > 100;
    }
}
