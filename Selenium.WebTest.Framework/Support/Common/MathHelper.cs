using System;

namespace Selenium.WebTest.Framework.Support.Common
{
    public static class MathHelper
    {

        // The format {0:[precision][type]}, like {0:4,1000000s}
        // % The number is multiplied by 100 and a % symbol is suffixed.
        //      and precision is interpreted as the number of significant figures to display (1.23 and 45.6 both have three significant figures).
        // f The number is formatted with decimal and thousands separators
        //      and the precision is interpreted as the number of digits after the decimal place
        //      Optionally a divisor may be specified with a comma after the precision.
        // s The number is formatted with decimal and thousands separators, 
        //      and the precision is interpreted as the number of significant figures ??
        //      number significant firstly then round
        //      Optionally a divisor may be specified with a comma after the precision.
        // a The number will be formatted with decimal and thousands separators, 
        //      and the precision is interpreted as the number of significant figures.
        //      Additionally, the number will be automatically scaled to the nearest power of 1000, 
        //      and an SI suffix (e.g.k, M, G) will be added to indicated the scale. 
        //      For example, using the format code {0:3a }, 12345 would be formatted as “12.3k”.

        public static string NumberFormat(double d, string format)
        {
            string result = "";

            string strFormat = format.TrimEnd('}');

            char type = strFormat[strFormat.Length - 1];
            strFormat = strFormat.Substring(0, strFormat.Length - 1);

            string[] str1 = strFormat.Split(':');
            string[] str2 = str1[1].Split(',');
            
            int precision = int.Parse(str2[0]);

            int divisor = 1;
            if (str2.Length > 1)
            {   
                divisor = int.Parse(str2[1]);
            }

            double quotient = d / divisor;

            switch (type)
            {
                case '%':
                    quotient = quotient * 100;
                    quotient = quotient.RoundToSignificantDigits(precision);
                    result = $"{quotient.ToString()}%";
                    break;
                case 'f':
                    quotient = Math.Round(quotient, precision);
                    result = quotient.ToString("N");
                    if (quotient > 1000)
                    {
                        result = quotient.ToString("N");
                    }
                    else
                    {
                        result = quotient.ToString();
                    }
                    break;
                case 's':
                    quotient = RoundToSignificantDigits(quotient, precision);
                    if (quotient > 1000)
                    { 
                        result = quotient.ToString("N");
                    }
                    else
                    {
                        // Here the precision is interpreted as the number of digits after the decimal place
                        quotient = Math.Round(quotient, precision);
                        result = quotient.ToString();
                    }
                    break;
                case 'a':
                    throw new ArgumentException($"Format {format} does not support right now.");
                default:
                    throw new ArgumentException($"Format {format} is not correct.");
            }
            

            return result;
        }

        public static double RoundToSignificantDigits(this double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }

        public static bool EqualsInDifference(this double d1, double d2, double difference)
        {
            return (Math.Abs(d1 - d2) <= difference);
        }

        public static double FromPercentageString(this string value)
        {
            return double.Parse(value.Replace("%", "")) / 100;
        }
    }
}
