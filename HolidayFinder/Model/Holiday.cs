namespace HolidayFinder.Model
{
    public class Holiday
    {
        private static readonly (int Month, int Day)[] fixedHolidays = new (int, int)[]
        {
        (1, 1),   // New Year's Day
        (4, 21),  // Tiradentes' Day
        (5, 1),   // Labor Day
        (9, 7),   // Independence Day
        (10, 12), // Our Lady of Aparecida
        (11, 2),  // All Souls' Day
        (11, 15), // Republic Day
        (12, 25)  // Christmas
        };

        private static List<DateTime> NewHolidays = new List<DateTime>();
        private static List<DateTime> NoLongerHolidays = new List<DateTime>();


        public bool IsHoliday(DateTime date)
        {
            if ((!NoLongerHolidays.Contains(date) && (IsFixedHoliday(date) || IsMovableHoliday(date) || NewHolidays.Contains(date))))
            {
                return true;
            }

            return false;
        }
        public bool IsFixedHoliday(DateTime date)
        {
            foreach (var holiday in fixedHolidays)
            {
                if (date.Month == holiday.Month && date.Day == holiday.Day)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsMovableHoliday(DateTime date)
        { 
            DateTime easter = CalculateEaster(date.Year);
            DateTime carnival = easter.AddDays(-47);
            DateTime goodFriday = easter.AddDays(-2);
            DateTime corpusChristi = easter.AddDays(60);

            if (date == carnival || date == goodFriday || date == easter || date == corpusChristi)
            {
                return true;
            }

            return false;
        }

        public static DateTime CalculateEaster(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }

       public bool changeHolidayDate(DateTime OldDate, DateTime NewDate)
        {
            if (IsHoliday(OldDate))
            {
                NoLongerHolidays.Add(OldDate);
                NewHolidays.Add(NewDate);

                return true;
            }
            return false;
            
        }

    }
}
