using System;

namespace IncomeViz.BuildingBlocks.ValidationHelpers
{
    public static class Check
    {
        public static void PositiveNumber(int value, string argumentName)
        {
            if (value <= 0) throw new ArgumentException(argumentName);
        }

        public static void GreaterThanZero(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException(nameof(amount));
        }

        public static void GreaterOrEqualZero(decimal amount)
        {
            if (amount < 0) throw new ArgumentException(nameof(amount));
        }

        public static void NotNullOrWhiteSpace(string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(argumentName);
        }

        public static void DateGreaterThan(DateTime executionDate, string argumentName, DateTime dateTime)
        {
            if (executionDate.Date <= dateTime.Date)
                throw new ArgumentException(argumentName);
        }
    }
}