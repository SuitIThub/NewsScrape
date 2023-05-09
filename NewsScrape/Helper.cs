using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsScrape
{
    public class Helper
    {
        static string time = "";
        static int value = 0;

        public static string id
        {
            get
            {
                string timeNow = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (time != timeNow)
                    value = 0;

                time = timeNow;

                return timeNow + value++.ToString("0000000000");
            }
        }

        public static string refineText(string text)
        {
            text = Regex.Replace(text, @"\s+", " ");

            return text;
        }

        public static string ConvertBytesToReadableSize(double bytes)
        {
            string[] sizes = { "KB", "MB", "GB" };
            int unitIndex = 0;

            bytes /= 1024;

            while (bytes >= 1024 && unitIndex < sizes.Length)
            {
                bytes /= 1024;
                unitIndex++;
            }

            return string.Format("{0:0.##} {1}", bytes, sizes[unitIndex]);
        }
    }
}
