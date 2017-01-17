using Minor.Case1.BackendService.WebApi.Models;
using System;
using System.Globalization;

namespace Minor.Case1.BackendService.WebApi.Helpers
{
    public class DateHelper
    {
        public static DateModel GetWeekBereik(int jaar, int weeknummer)
        {
            var startDatum = GetEersteDagVanDeWeek(jaar, weeknummer);
            return new DateModel()
            {
                StartDatum = startDatum,
                EindDatum = startDatum.AddDays(6),
            };

        }


        private static DateTime GetEersteDagVanDeWeek(int jaar, int weeknummer)
        {
            DateTime jan1 = new DateTime(jaar, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weeknummer;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }
}
