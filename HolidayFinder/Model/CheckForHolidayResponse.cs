namespace HolidayFinder.Model
{
    public class CheckForHolidayResponse
    {
        public DateTime InputDate {  get; set; }
        public bool IsHoliday { get; set; }
        public bool IsBusinessDay { get; set; }
        public string message { get; set; }
    }
}
