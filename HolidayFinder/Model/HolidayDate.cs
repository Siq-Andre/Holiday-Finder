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
    }
}
