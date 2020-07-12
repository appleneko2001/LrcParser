using System;
using static Opportunity.LrcParser.TimeSpanExtension;

namespace Opportunity.LrcParser
{
    /// <summary>
    /// Factory for timestamps.
    /// </summary>
    public static class Timestamp
    {
        /// <summary>
        /// Create new <see cref="DateTime"/> of timestamp.
        /// </summary>
        /// <param name="minute">Minute, > 0.</param>
        /// <param name="second">Second, 0 ~ 59.</param>
        /// <param name="millisecond">Millisecond, 0 ~ 999.</param>
        /// <returns><see cref="DateTime"/> of timestamp.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Argument out of range.</exception>
        public static TimeSpan Create(int minute, int second, int millisecond)
        {
            if (minute < 0)
                throw new ArgumentOutOfRangeException(nameof(minute));
            if (unchecked((uint)second >= 60U))
                throw new ArgumentOutOfRangeException(nameof(second));
            if (unchecked((uint)millisecond >= 1000U))
                throw new ArgumentOutOfRangeException(nameof(millisecond));
            return new TimeSpan(0,0,minute, second, millisecond);
        }

        /// <summary>
        /// Create new <see cref="DateTime"/> of timestamp.
        /// </summary>
        /// <param name="second">Second, > 0.</param>
        /// <param name="millisecond">Millisecond, 0 ~ 999.</param>
        /// <returns><see cref="DateTime"/> of timestamp.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Argument out of range.</exception>
        public static TimeSpan Create(int second, int millisecond)
        {
            if (second < 0)
                throw new ArgumentOutOfRangeException(nameof(second));
            if (unchecked((uint)millisecond >= 1000U))
                throw new ArgumentOutOfRangeException(nameof(millisecond));
            return new TimeSpan(0, 0, 0, second, millisecond);
        }

        /// <summary>
        /// Create new <see cref="DateTime"/> of timestamp.
        /// </summary>
        /// <param name="millisecond">Millisecond, > 0.</param>
        /// <returns><see cref="DateTime"/> of timestamp.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Argument out of range.</exception>
        public static TimeSpan Create(int millisecond)
        {
            if (millisecond < 0)
                throw new ArgumentOutOfRangeException(nameof(millisecond));
            return new TimeSpan(0,0,0,0,millisecond);
        }
    }
}
