using System;

namespace Ni
{
    public static class RandomStringGenerator
    {
        static Random _rd = new Random();
        public static string CreateString(int stringLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[_rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
