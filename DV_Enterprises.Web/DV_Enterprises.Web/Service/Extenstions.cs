using System;
using System.Data.Linq;

namespace DV_Enterprises.Web.Service
{
    public static class Extenstions
    {
        #region String Extenstions


        /// <summary>
        /// Converts CamelCase to regularly spaced sentence
        /// Before: LightingIntensity
        /// After:  Lighting Intensity
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DeCamelize(this string s)
        {
            var temp = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                temp += (Char.IsLetter(s[i]) && Char.IsUpper(s[i]) && i != 0)
                    ? string.Format(" {0}", s[i])
                    : s[i].ToString();
            }
            return temp;
        }

        public static string TimestampToString(this Binary binary)
        {
            byte[] binarybytes = binary.ToArray();
            string result = "";
            foreach (byte b in binarybytes)
            {
                result += b.ToString() + "|";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }


        public static Binary StringToTimestamp(this string s)
        {
            string[] arr = s.Split('|');
            byte[] bytes = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bytes[i] = Convert.ToByte(arr[i]);
            }
            return bytes;
        }

        public static int? ToNullableInt(this string s)
        {
            int result;
            if (!int.TryParse(s, out result))
                result = 0;
            return result == 0 ? (int?)null : result;
        }

        #endregion


        #region Binary Extenstions

        public static ulong TimestampToUlong(this Binary binary)
        {
            return BitConverter.ToUInt64(binary.ToArray(), 0);
        }

        #endregion


        #region ULong Extenstions

        public static Binary UlongToTimestamp(this ulong value)
        {
            return new Binary(BitConverter.GetBytes(value));
        }

        #endregion
    }
}