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


    }
}
