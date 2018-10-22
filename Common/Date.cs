using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace Common
{
	public struct Date : IEquatable<Date>, IEquatable<DateTime>, IComparable<Date>, IComparable, IFormattable
	{
		/// <summary>
		/// Inception is 1/1/1
		/// </summary>
		private readonly long _daysSinceInception;

		private Date(long daysSinceInception)
		{
			_daysSinceInception = daysSinceInception;
		}

		public Date(int year, int month, int day)
		{
			var dateTime = new DateTime(year, month, day);
			_daysSinceInception = (long)dateTime.Subtract(DateTime.MinValue).TotalDays;
		}

		public DayOfWeek DayOfWeek => ToDateTime().DayOfWeek;

		public int Year => ToDateTime().Year;

		public string TwoDigitYear => ToDateTime().ToString("yy");

		public int Month => ToDateTime().Month;

		public int Day => ToDateTime().Day;

		public int Quarter => (ToDateTime().Month - 1) / 3 + 1;

		[Pure]
		public bool InSameMonthAs(Date value)
		{
			return Month == value.Month && Year == value.Year;
		}

		#region comparison
		#region IComparable<Date> Members

		public int CompareTo(Date other)
		{
			return _daysSinceInception.CompareTo(other._daysSinceInception);
		}

		#endregion

		#region IEquatable<Date> Members

		public bool Equals(Date other)
		{
			return _daysSinceInception == other._daysSinceInception;
		}

		#endregion

		#region IEquatable<DateTime> Members

		public bool Equals(DateTime other)
		{
			return ToDateTime().Equals(other);
		}

		#endregion

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return Equals((Date)obj);
		}

		public override int GetHashCode()
		{
			return ToDateTime().GetHashCode();
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;
			if (obj is Date)
				return CompareTo((Date)obj);
			if (obj is DateTime)
				return CompareTo(FromDateTime((DateTime)obj));
			return 0;
		}

		public static bool operator ==(Date source, Date other)
		{
			return source.Equals(other);
		}

		public static bool operator !=(Date source, Date other)
		{
			return !(source == other);
		}

		public static bool operator >(Date source, Date other)
		{
			return source._daysSinceInception > other._daysSinceInception;
		}

		public static bool operator >=(Date source, Date other)
		{
			return source._daysSinceInception >= other._daysSinceInception;
		}

		public static bool operator <(Date source, Date other)
		{
			return source._daysSinceInception < other._daysSinceInception;
		}

		public static bool operator <=(Date source, Date other)
		{
			return source._daysSinceInception <= other._daysSinceInception;
		}

		public static Date? Min(params Date?[] dates)
		{
			return dates.Where(d => d.HasValue).OrderBy(d => d).FirstOrDefault();
		}

		public static Date Min(params Date[] dates)
		{
			return dates.OrderBy(d => d).First();
		}

		public static Date? Max(params Date?[] dates)
		{
			return dates.Where(d => d.HasValue).OrderBy(d => d).LastOrDefault();
		}

		public static Date Max(params Date[] dates)
		{
			return dates.OrderBy(d => d).Last();
		}
		#endregion

		#region conversion
		public DateTime ToDateTime()
		{
			return DateTime.MinValue.AddDays(_daysSinceInception);
		}

		private static Date FromDateTime(DateTime source)
		{
			var difference = (long)source.Subtract(DateTime.MinValue).TotalDays;
			return new Date(difference);
		}

		public static explicit operator Date(DateTime source)
		{
			return FromDateTime(source);
		}

		public static implicit operator DateTime(Date source)
		{
			return source.ToDateTime();
		}
		#endregion

		#region output
		public override string ToString()
		{
			return ToDateTime().ToShortDateString();
		}

		public string ToString(string format)
		{
			return ToDateTime().ToString(format);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return ToDateTime().ToString(format, formatProvider);
		}

		public string ToShortMonthYear()
		{
			return ToString("MM/yy");
		}

		public string ToFullMonthAndYear()
		{
			return ToString("MMMM yyyy");
		}

		public string ToFullMonthAndYearNoSpaces()
		{
			return ToString("MMMMyyyy");
		}

		public string ToInternationalDateFormat()
		{
			return ToString("yyyy-MM-dd");
		}
		#endregion

		#region mutation
		[Pure]
		public Date AddDays(int daysToAdd)
		{
			return new Date(_daysSinceInception + daysToAdd);
		}

		[Pure]
		public Date AddYears(int yearsToAdd)
		{
			return FromDateTime(ToDateTime().AddYears(yearsToAdd));
		}

		[Pure]
		public Date AddMonths(int monthsToAdd)
		{
			return FromDateTime(ToDateTime().AddMonths(monthsToAdd));
		}

		public static Date FirstDayOf(int year)
		{
			return FromDateTime(new DateTime(year, 1, 1));
		}

		public static Date Parse(string date)
		{
			return FromDateTime(DateTime.Parse(date));
		}

		public static Date ParseExact(string date, string format, IFormatProvider provider)
		{
			return FromDateTime(DateTime.ParseExact(date, format, provider));
		}

		public static Date ParseExact(string date, string[] formats, IFormatProvider provider, DateTimeStyles style)
		{
			return FromDateTime(DateTime.ParseExact(date, formats, provider, style));
		}

		public static Date MinValue => FromDateTime(DateTime.MinValue);

		public static Date MaxValue => FromDateTime(DateTime.MaxValue);

		public static DateTime operator +(Date source, TimeSpan timeSpan)
		{
			return source.Add(timeSpan);
		}

		[Pure]
		public DateTime Add(TimeSpan timeSpan)
		{
			return ToDateTime().Add(timeSpan);
		}

		public static long operator -(Date source, Date other)
		{
			return source.Subtract(other);
		}

		[Pure]
		public long Subtract(Date other)
		{
			return _daysSinceInception - other._daysSinceInception;
		}

		[Pure]
		public DateTime Subtract(TimeSpan other)
		{
			return ToDateTime().Subtract(other);
		}

		[Pure]
		public Date EndOfMonth()
		{
			return new Date(Year, Month, 1).AddMonths(1).AddDays(-1);
		}
		#endregion

		[Pure]
		public static string MonthName(int month, string format = "MMMM")
		{
			return new Date(1900, month, 1).ToString(format);
		}

		[Pure]
		public Date FirstDayOfMonth()
		{
			return new Date(Year, Month, 1);
		}

		[Pure]
		public Date LastDayOfMonth()
		{
			return FirstDayOfMonth().AddMonths(1).AddDays(-1);
		}

		[Pure]
		public Date FirstDayOfQuarter()
		{
			var quarterNumber = (Month - 1) / 3 + 1;
			return new Date(Year, (quarterNumber - 1) * 3 + 1, 1);
		}
	}
}