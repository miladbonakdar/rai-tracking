using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.ValueObjects
{
    public class DateTimeRange : ValueObject<DateTimeRange>
    {
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }

        public DateTimeRange(DateTime start, DateTime end)
        {
            Guard.ForPrecedesDate(start, end, "start");
            Start = start;
            End = end;
        }

        public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
        {
        }

        protected DateTimeRange() { }

        public int DurationInMinutes()
        {
            return (End - Start).Minutes;
        }

        public DateTimeRange NewEnd(DateTime newEnd)
        {
            return new DateTimeRange(this.Start, newEnd);
        }
        public DateTimeRange NewDuration(TimeSpan newDuration)
        {
            return new DateTimeRange(this.Start, newDuration);
        }
        public DateTimeRange NewStart(DateTime newStart)
        {
            return new DateTimeRange(newStart, this.End);
        }

        public static DateTimeRange CreateOneDayRange(DateTime day)
        {
            return new DateTimeRange(day, day.AddDays(1));
        }

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
        {
            return new DateTimeRange(startDay, startDay.AddDays(7));
        }

        public bool Overlaps(DateTimeRange dateTimeRange)
        {
            return this.Start < dateTimeRange.End &&
                   this.End > dateTimeRange.Start;
        }

        public override bool IsEmpty() =>
            default(DateTime) == Start &&
            default(DateTime) == End ;

        public static DateTimeRange CreateEmpty() =>
            new DateTimeRange();
    }
}
