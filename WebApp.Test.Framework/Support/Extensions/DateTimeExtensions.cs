using System;
using System.Configuration;
using System.Xml;

namespace WebApp.Test.Framework.Support.Extensions
{
    public static class DateTimeExtensions
    {

        // to '2017-07-25T09:24:59Z' format
        public static string ToXmlDateTime(this DateTime dateTime)
        {
            return XmlConvert.ToString(dateTime, XmlDateTimeSerializationMode.Utc);
        }

        public static string ToXmlDateTime(this DateTime dateTime, XmlDateTimeSerializationMode mode = XmlDateTimeSerializationMode.Utc)
        {
            return XmlConvert.ToString(dateTime, mode);
        }
    }
}
