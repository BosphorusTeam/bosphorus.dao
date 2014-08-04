using System;
using System.Text;
using NHibernate.Linq;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Soundex
{
    //TODO: Not working correctly so it is internal
    //http://weblogs.asp.net/ricardoperes/custom-linq-extensions-for-nhibernate
    public static class StringExtensions
    {
        private const String values = "01230120022455012623010202";
        private const Int32 encodingLength = 4;

        [LinqExtensionMethod]
        public static string Soundex(this string input)
        {
            Char prevChar = ' ';

            input = Normalize(input);

            if (input.Length == 0)
            {
                return (input);
            }

            StringBuilder builder = new StringBuilder();
            builder.Append(input[0]);

            for (Int32 i = 1; ((i < input.Length) && (builder.Length < encodingLength)); ++i)
            {
                Char c = values[input[i] - 'A'];

                if ((c != '0') && (c != prevChar))
                {
                    builder.Append(c);
                    prevChar = c;
                }
            }

            while (builder.Length < encodingLength)
            {
                builder.Append('0');
            }

            return (builder.ToString());
        }


        private static String Normalize(String text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (Char c in text)
            {
                if (Char.IsLetter(c) == true)
                {
                    builder.Append(Char.ToUpper(c));
                }
            }

            return (builder.ToString());
        }
    }

}
