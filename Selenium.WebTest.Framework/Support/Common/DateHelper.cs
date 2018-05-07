using System;
using System.Configuration;

namespace Selenium.WebTest.Framework.Support.Common
{
    public class DateHelper
    {
        public string GetDateAsString(string dateTimeString)
        {
            return GetDateAsString(StringToDateTime(dateTimeString));
        }

        public string GetDateAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("d");
            return dateTimeString;
        }

        public string GetDateHoursMinutesAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("g");
            return dateTimeString;
        }

        public string GetDateHoursMinutesAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("g");
            return dateTimeString;
        }
        public string GetDateHoursMinutesSecondsMillisecondsTimezoneAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("o");
            return dateTimeString;
        }
        public string GetDateHoursMinutesSecondsMillisecondsTimezoneAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("o");
            return dateTimeString;
        }
        public string GetDateHoursMinutesSecondsMillisecondsAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return dateTimeString;
        }

        public string GetDateHoursMinutesSecondsMillisecondsAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return dateTimeString;
        }

        public string GetYearMonthDayAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd");
            return dateTimeString;
        }

        public DateTime StringToDateTime(string dateTime)
        {
            string convertDateTime = "";
            switch (dateTime.ToUpper())
            {
                case "PAST_INFINITY_DATE":
                    convertDateTime = ConfigurationManager.AppSettings["PAST_INFINITY_DATE"];
                    break;
                case "FUTURE_INFINITY_DATE":
                    convertDateTime = ConfigurationManager.AppSettings["FUTURE_INFINITY_DATE"];
                    break;
                default:
                    convertDateTime = dateTime;
                    break;
            }

            return ConvertStringToDateTime(convertDateTime);
        }

        public DateTime AddMinutesHoursDays(DateTime dateTime, string type, int amount)
        {
            switch (type.ToUpper())
            {
                case "SECOND":
                case "SECONDS":
                    return dateTime.AddSeconds(amount);
                case "MINUTE":
                case "MINUTES":
                    return dateTime.AddMinutes(amount);
                case "HOUR":
                case "HOURS":
                    return dateTime.AddHours(amount);
                case "DAY":
                case "DAYS":
                    return dateTime.AddDays(amount);
                default:
                    throw new Exception("Unrecognised ");
            }
        }

        private DateTime ConvertStringToDateTime(string value)
        {
            return Convert.ToDateTime(value);
        }
    }
}
