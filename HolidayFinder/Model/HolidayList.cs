using System.Text.Json;

namespace HolidayFinder.Model
{
    public class HolidayList
    {
        public List<HolidayDate> Holidays { get; set; }

        public HolidayList()
        {
            var HolidaysJsonPath = "Data/Holidays.json";

            var jsonData = System.IO.File.ReadAllText(HolidaysJsonPath);

            List<HolidayDate> HolidayDatesFromJson = JsonSerializer.Deserialize<List<HolidayDate>>(jsonData);

            Holidays = HolidayDatesFromJson;
        }

        public List<HolidayDate> showHolidays (int Page)
        {
            var AmountOfItemsPerPage = 5;
            var SkipAmount = AmountOfItemsPerPage * Page;

            var PageHolidays = Holidays
                .Skip(SkipAmount)
                .Take(AmountOfItemsPerPage)
                .ToList();

            return PageHolidays;
        }

        public string AddHolidaysToList(int day, int month, int year, string holydayName)
        {
            var NewHoliday = new HolidayDate(day, month, year, holydayName);
            var response = "";

            if (Holidays.Contains(NewHoliday))
            {
                response = "This holiday is already on the list";
                return response;
            }
            Holidays.Add(NewHoliday);
            response = "Holiday added to the list";
            return response;
        }

    }
}
