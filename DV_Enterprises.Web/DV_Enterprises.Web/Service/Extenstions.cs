using System;
using System.Data.Linq;

namespace DV_Enterprises.Web.Service
{
    public static class Extenstions
    {
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
        public static ulong TimestampToUlong(this Binary binary)
        {
            return BitConverter.ToUInt64(binary.ToArray(), 0);
        }

        public static Binary UlongToTimestamp(this ulong value)
        {
            return new Binary(BitConverter.GetBytes(value));
        }
    }
}