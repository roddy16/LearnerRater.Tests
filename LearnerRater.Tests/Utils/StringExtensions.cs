using System;
using System.Text;

namespace LearnerRater.Tests.Utils
{
    public static class StringExtensions
    {
        public static string CreateLargeString(this string stringSize)
        {
            //This is used for creating very large strings for validation purposes. It has been intentionally designed to be simple
            int size = Convert.ToInt32(stringSize);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < size + 1; i++)
                builder.Append("A");

            return $"{builder}";
        }
    }
}
