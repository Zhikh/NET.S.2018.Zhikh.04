namespace Extension
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Converts double value into string representation of a real number in the format IEEE 754
        /// </summary>
        /// <param name="value"> Value for converting </param>
        /// <returns> String representation of a real number in the format IEEE 754 </returns>
        public static string ToBinaryString(this double value)
        {
            int length = sizeof(long) * 8;
            short[] result = new short[length]; 

            unsafe
            {
                long temp = *(long*)(&value);
                int j = 0;

                for (int i = length - 1; i >= 0; i--)
                {
                    result[j++] = (short)(temp >> i & 1);
                }
            }

            return string.Concat(result);
        }
    }
}
