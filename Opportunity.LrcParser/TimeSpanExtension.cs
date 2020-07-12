using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Opportunity.LrcParser
{
    internal static class TimeSpanExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ToString(this TimeSpan dateTime, string mFormat, string smSep, string sFormat)
        {
            var t = dateTime.Ticks;
            var m = t / TICKS_PER_MINUTE;
            t -= m * TICKS_PER_MINUTE;
            var s = (double)t / TICKS_PER_SECOND;
            return m.ToString(mFormat) + smSep + s.ToString(sFormat);
        }
 
        public static string ToLrcString(this TimeSpan timeSpan)
            => timeSpan.ToString("D2", ":", "00.00");

        public static string ToLrcStringRaw(this TimeSpan timeSpan)
            => timeSpan.ToString("D2", ":", "00.00######");

        public static string ToLrcStringShort(this TimeSpan timeSpan)
            => timeSpan.ToString("D2", ":", "00");

        public static bool TryParseLrcString(string value, int start, int end, out TimeSpan result)
        {
            var m = 0;
            var s = 0;
            var t = 0;

            var i = start;
            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                    m = m * 10 + v;
                else if (value[i] == ':')
                {
                    i++;
                    break;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }

            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                    s = s * 10 + v;
                else if (value[i] == '.')
                {
                    i++;
                    break;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }

            var weight = (int)(TICKS_PER_SECOND / 10);
            for (; i < end; i++)
            {
                var v = value[i] - '0';
                if (v >= 0 && v <= 9)
                {
                    t += weight * v;
                    weight /= 10;
                }
                else if (char.IsWhiteSpace(value, i))
                {
                    continue;
                }
                else
                {
                    goto ERROR;
                }
            }
            ;
            result = new TimeSpan(t + TICKS_PER_SECOND * s + TICKS_PER_MINUTE * m); 
            return true;

            ERROR:
            result = default;
            return false;
        }

        public const long TICKS_PER_MINUTE = TICKS_PER_SECOND * 60;
        public const long TICKS_PER_SECOND = TICKS_PER_MILLISECOND * 1000;
        public const long TICKS_PER_MILLISECOND = 10_000;
         
    }
}
