namespace HolidayFinder.Model
{
    public class HolidayDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsBusinessDay { get; set; }
        public string HolidayName { get; set; }

        public HolidayDate() { }

        public HolidayDate (int day, int month, int year, string holydayName)
        {
            HolidayFinderMethods holidayFinder = new HolidayFinderMethods ();

            Day = day;
            Month = month;
            Year = year;
            HolidayName = holydayName;

            DateTime date = new DateTime (year, month, day);

            IsHoliday = holidayFinder.IsHoliday(date);
            IsBusinessDay = holidayFinder.isBusinessDay(date);

        }
    }
}
