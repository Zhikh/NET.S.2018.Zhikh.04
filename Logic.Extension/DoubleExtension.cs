using System.Runtime.InteropServices;

namespace Extension
{
    public static class DoubleExtension
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLong
        {
            [FieldOffset(0)]
            public double AsDouble;

            [FieldOffset(0)]
            public long AsLong;
        }

        #region Public methods
        /// <summary>
        /// Converts double value into string representation of a real number in the format IEEE 754
        /// </summary>
        /// <param name="value"> Value for converting </param>
        /// <returns> String representation of a real number in the format IEEE 754 </returns>
        public static string ToBinaryStringUnsafe(this double value)
        {
            long temp;

            unsafe
            {
                temp = *(long*)(&value);
            }

            return GetBitsString(temp);
        }

        public static string ToBinaryString(this double value)
        {
            var result = new DoubleLong();
            result.AsDouble = value;

            return GetBitsString(result.AsLong);
        }
        #endregion

        #region Private methods
        private static string GetBitsString(long value)
        {
            int length = sizeof(long) * 8;
            short[] result = new short[length];
            int j = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                result[j++] = (short)(value >> i & 1);
            }

            return string.Concat(result);
        }
        #endregion
    }
}
