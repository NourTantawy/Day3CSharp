using System;


namespace Project3C_
{
    public class Duration
    {
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }

        public Duration()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public Duration(int _seconds)
        {
            hours = _seconds / 3600;

            _seconds %= 3600;

            minutes = _seconds / 60;

            _seconds %= 60;

            seconds = _seconds;
        }
        public Duration(int _hours, int _minutes, int _seconds)
        {
            // seconds
            _minutes += _seconds / 60;
            _seconds %= 60;
            seconds = _seconds;

            // minutes
            _hours += _minutes / 60;
            _minutes %= 60;
            minutes = _minutes;

            // hours 
            hours = _hours;

        }

        public override string ToString()
        {
            if (hours == 0 && minutes == 0)
                return $"Seconds: {seconds}";

            if (hours == 0)
                return $"Minutes: {minutes}, Seconds: {seconds}";

            return $"Hours: {hours}, Minutes: {minutes}, Seconds: {seconds}";
        }
        public override bool Equals(object? obj)
        {
            Duration d = obj as Duration ?? new Duration();

            return (this.hours == d.hours && this.minutes == d.minutes && this.seconds == d.seconds);
        }
        public override int GetHashCode() // ------------------------------------------------------------------
        {
            return base.GetHashCode();
        }


        // Operator overloading
        public static bool operator ==(Duration d1, Duration d2)
        {
            return (d1.hours == d2.hours && d1.minutes == d2.minutes && d1.seconds == d2.seconds);
        }

        public static bool operator !=(Duration d1, Duration d2)
        {
            return (d1.hours != d2.hours || d1.minutes != d2.minutes || d1.seconds != d2.seconds);
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            if (d1.hours < d2.hours) return true;
            if (d1.minutes < d2.minutes) return true;
            if (d1.seconds <  d2.seconds) return true;
            return false;
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            if (d1.hours > d2.hours) return true;
            if (d1.minutes > d2.minutes) return true;
            if (d1.seconds > d2.seconds) return true;
            return false;
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            if (d1.hours <= d2.hours) return true;
            if (d1.minutes <= d2.minutes) return true;
            if (d1.seconds <= d2.seconds) return true;
            return false;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            if (d1.hours >= d2.hours) return true;
            if (d1.minutes >= d2.minutes) return true;
            if (d1.seconds >= d2.seconds) return true;
            return false;
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.hours + d2.hours, d1.minutes + d2.minutes, d1.seconds + d2.seconds);
        }

        public static Duration operator +(Duration d1, int _seconds)
        {
            return new Duration(d1.hours, d1.minutes, d1.seconds + _seconds);
        }

        public static Duration operator +(int _seconds, Duration d1)
        {
            return new Duration(d1.hours, d1.minutes, d1.seconds + _seconds);
        }

        public static Duration operator ++(Duration d1)
        {
            return new Duration(d1.hours + 1, d1.minutes + 1, d1.seconds + 1);
        }

        public static Duration operator --(Duration d1)
        {
            return new Duration(d1.hours - 1, d1.minutes - 1, d1.seconds - 1);
        }

        public static Duration operator -(Duration d1)
        {
            if (d1.hours < 0 || d1.minutes < 0 || d1.seconds < 0)
                Console.WriteLine("Chaning negative values to positive");
            else
                Console.WriteLine("Duration can't be a negative value!!!!!!!!!");

            return new Duration(Math.Abs(d1.hours), Math.Abs(d1.minutes), Math.Abs(d1.seconds));
        }

        public static implicit operator bool(Duration d1)
        {
            return (d1.hours == 0) && (d1.minutes == 0) && (d1.seconds == 0);
        }

        public static explicit operator DateTime(Duration d1)
        {
            DateTime dt = DateTime.Now;
            TimeSpan time = new TimeSpan(d1.hours, d1.minutes, d1.seconds);

            return dt.Add(time);
        }
    }   
}
