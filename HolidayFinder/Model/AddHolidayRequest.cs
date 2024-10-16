namespace HolidayFinder.Model
{
    public class AddHolidayRequest
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string HolidayName { get; set; }

        public AddHolidayRequest(int day, int month, int year, string holidayName)
        {
            Day = day;
            Month = month;
            Year = year;
            HolidayName = holidayName;
        }
    }
}
