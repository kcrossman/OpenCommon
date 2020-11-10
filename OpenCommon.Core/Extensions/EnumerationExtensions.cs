using System;

namespace OpenCommon.Core.Extensions
{
    public static class EnumerationExtensions
    {
        public static bool Contains<T>(this Enum type, T value)
        {
            return ((int)(object)type & (int)(object)value) == (int)(object)value;
        }

        public static bool Equals<T>(this Enum type, T value)
        {
            return (int)(object)type == (int)(object)value;
        }

        public static T Add<T>(this Enum type, T value)
        {
            return (T)(object)((int)(object)type | (int)(object)value);
        }

        public static T Remove<T>(this Enum type, T value)
        {
            return (T)(object)((int)(object)type & ~(int)(object)value);
        }
    }
}
