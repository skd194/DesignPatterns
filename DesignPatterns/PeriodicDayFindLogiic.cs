using System;

namespace DesignPatterns
{
    public class PeriodicDayFindLogiic
    {
        public void Execute()
        {
            var processFromDate = new DateTime(2018, 8, 27);
            var processToDate = new DateTime(2018, 9, 26);


            const int periodicity = 3;

            var setup = new
            {
                EffectiveFrom = new DateTime(2017, 3, 27),
                EffectiveTo = new DateTime(2018, 12, 31)
            };

            var adjustedEffectiveFromDate = setup.EffectiveFrom.Day != processFromDate.Day
                ? setup.EffectiveFrom
                : setup.EffectiveFrom.AddDays(1);

            var isMatured = processFromDate.MonthDifference(adjustedEffectiveFromDate) / periodicity + 1 ==
                            processToDate.MonthDifference(setup.EffectiveFrom) / periodicity;


            Console.WriteLine(
                $"Process From Date {processFromDate} \nProcess To Date: {processToDate} \nEffective From: {setup.EffectiveFrom} \nEffective To: {setup.EffectiveTo}");

            Console.WriteLine($"IS MATURED : {isMatured}");
        }
    }

    public static class DateTimeHelper
    {
        public static int MonthDifference(this DateTime date2, DateTime date1)
        {
            var isDate2Latest = (date2 - date1).TotalDays >= 0;
            var latestDate = isDate2Latest ? date2 : date1;
            var earliestDate = isDate2Latest ? date1 : date2;

            return (latestDate.Year - earliestDate.Year) * 12 +
                   (latestDate.Month - earliestDate.Month) +
                   (latestDate.Day >= earliestDate.Day ? 0 : -1);
        }
    }
}
