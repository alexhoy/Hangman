using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Word
    {

        public List<char> WordtoArray(String s)
        {
            List<char> a = s.ToList<char>();
            return a;

        }



        public String GetWord() {

            String[] s = System.IO.File.ReadAllLines("WordList.txt");
            Random ran = new Random();
            String strWord = s[ran.Next(0, s.Length)];
            return strWord;

        }



    }
}
