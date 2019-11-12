using System;

namespace Geek
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "3[b4[]2[za]]";
            var p = new Program();
            Console.WriteLine(p.Solve(s, 0, s.Length - 1));
        }

        public int FindBracketPair(string s, int start)
        {
            int c = 0;
            for (int i = start + 1; i < s.Length; i++)
            {
                if (s[i] == ']')
                {
                    if (c == 0)
                    {
                        return i;
                    }

                    c--;
                }
                if (s[i] == '[')
                {
                    c++;
                }
            }
            return -1;
        }


        public string Solve(string s, int start, int end)
        {
            int i = start;
            int multiplier = 0;
            string substr = "";
            while (i <= end)
            {
                if (s[i] <= '9' && s[i] >= '0')
                {
                    multiplier = multiplier * 10 + int.Parse(s[i].ToString());
                    i++;
                }
                else if (s[i] == '[')
                {
                    int pair = FindBracketPair(s, i);
                    string subResult = Solve(s, i + 1, pair - 1);
                    i = pair + 1;
                    for (int m = 0; m < multiplier; m++)
                    {
                        substr = substr + subResult;
                    }
                    multiplier = 0;
                }
                else
                {
                    substr = substr + s[i];
                    multiplier = 0;
                    i++;
                }
            }

            return substr;
        }
    }
}
