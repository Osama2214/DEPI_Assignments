
using System;

namespace Assignment04Project3
{
    public class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        // Default Constructor

        public Duration()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }


        // Constructor with Hours, Minutes, Seconds

        public Duration(int hours, int minutes, int seconds)
        {
            int totalSeconds = hours * 3600
                             + minutes * 60
                             + seconds;

            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }


        // Constructor with Total Seconds

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }


        // ToString

        public override string ToString()
        {
            if (Hours > 0)
            {
                return string.Format(
                    "Hours: {0}, Minutes :{1}, Seconds :{2}",
                    Hours, Minutes, Seconds
                );
            }
            else if (Minutes > 0)
            {
                return string.Format(
                    "Minutes :{0}, Seconds :{1}",
                    Minutes, Seconds
                );
            }
            else
            {
                return "Seconds :" + Seconds;
            }
        }


        // Equals

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Duration))
                return false;

            Duration other = (Duration)obj;

            return Hours == other.Hours
                && Minutes == other.Minutes
                && Seconds == other.Seconds;
        }


        // GetHashCode

        public override int GetHashCode()
        {
            return Hours.GetHashCode()
                 ^ Minutes.GetHashCode()
                 ^ Seconds.GetHashCode();
        }
    }
}