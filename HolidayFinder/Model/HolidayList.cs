using System.Text.Json;

namespace HolidayFinder.Model
{
    public class HolidayList
    {
        public List<HolidayDate> Holidays { get; set; }

        public string GetJsonHolidays()
        {
            var HolidaysJsonPath = "Data/Holidays.json";

            if (!System.IO.File.Exists(HolidaysJsonPath))
            {
                return ("The JSON file was not found.");
            }

            var jsonData = System.IO.File.ReadAllText(HolidaysJsonPath);

            List<HolidayDate> HolidayDatesFromJson = JsonSerializer.Deserialize<List<HolidayDate>>(jsonData);

            if (HolidayDatesFromJson == null || HolidayDatesFromJson.Count == 0)
            {
                return ("The JSON file is invalid.");
            }

            Holidays = HolidayDatesFromJson;
            return ("The list of holidays was updated");
        }
    }
}
