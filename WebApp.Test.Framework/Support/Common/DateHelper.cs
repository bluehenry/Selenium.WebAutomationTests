using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Test.Framework.Support.Common
{
    public class DateHelper
    {
        public string getDateAsString(string dateTimeString)
        {
            return getDateAsString(stringToDateTime(dateTimeString));
        }

        public string getDateAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("d");
            return dateTimeString;
        }

        public string getDateHoursMinutesAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("g");
            return dateTimeString;
        }

        public string getDateHoursMinutesAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("g");
            return dateTimeString;
        }
        public string getDateHoursMinutesSecondsMillisecondsTimezoneAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("o");
            return dateTimeString;
        }
        public string getDateHoursMinutesSecondsMillisecondsTimezoneAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("o");
            return dateTimeString;
        }
        public string getDateHoursMinutesSecondsMillisecondsAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return dateTimeString;
        }

        public string getDateHoursMinutesSecondsMillisecondsAsString(DateTimeOffset dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return dateTimeString;
        }

        public string GetYearMonthDayAsString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-dd");
            return dateTimeString;
        }

        public DateTime stringToDateTime(string dateTime)
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
