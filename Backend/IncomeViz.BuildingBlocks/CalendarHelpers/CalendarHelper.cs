using System;
using System.Collections.Generic;

namespace IncomeViz.BuildingBlocks.CalendarHelpers
{
    public static class CalendarHelper
    {
        public static IEnumerable<DateTime> EachCalendarDay(DateTime startDate, DateTime endDate)
        {
            for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1))
                yield return date;
        }
    }
}
