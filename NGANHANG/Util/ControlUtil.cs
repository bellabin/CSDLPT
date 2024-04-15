using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NGANHANG.Util
{
    class ControlUtil
    {
        public readonly static int MAX_RECORD_STACK = 50;

        public readonly static string BRAND_DISPLAY_NAME = "TENCN";
        public readonly static string BRAND_VALUE_NAME = "TENSERVER";


        public static System.Windows.Forms.Form CheckFormExists(System.Windows.Forms.Form parent, Type ftype)
        {
            foreach (System.Windows.Forms.Form f in parent.MdiChildren)
            {
                if (f.GetType() == ftype)
                    return f;
            }
            return null;
        }

        public static string RemoveDuplicateSpace(string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }

        public static String CapitalizeFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException();
            string res = "";
            string[] words = Regex.Split(str, @"\s+");
            foreach (string word in words)
            {
                res += $"{word.First().ToString().ToUpper()}{word.Substring(1).ToLower()} ";
            }
            return res.TrimEnd();
        }
    }
}
