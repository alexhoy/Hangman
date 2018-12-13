using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        #region Defines
        Word w = new Word();
        String strWord;
        String output;
        List<char> WordAsArray = new List<char>();
        List<char> HiddenWord = new List<char>();
        int intNumberOfGuesses;
        int intMaxGuesses;
        int intCorrectGuesses;
        int intIncorrectGuesses;
        List<char> GuessedLetters = new List<char>();
        #endregion Defines
        


        public MainWindow()
        {

            InitializeComponent();
            Init();
            Updatelbl();

        }

        public void Init()
        {

            intNumberOfGuesses = 0;
            intMaxGuesses = 10;
            strWord = w.GetWord();

            if (strWord.Length < 3)
            {
                strWord = w.GetWord();
            }

            else
            {

                WordAsArray = w.WordtoArray(strWord);
                HiddenWord = w.WordtoArray(strWord);

                for (int i = 0; i < WordAsArray.Count; i++) //Hidden word array populated by _ to WordArray length
                {

                    HiddenWord[i] = Convert.ToChar("_");

                }
                Updatelbl();

                this.Title = strWord;
            }
        }


        public void CheckGuess(char c)
        {

            for (int i = 0; i < WordAsArray.Count; i++)
            {
                if (WordAsArray[i] == c  && !GuessedLetters.Contains(c)) //Only need to update the "hiddenlabel" if both the chars match, and it hasn't already been guessed before
                {

                    UpdateHidden(c, i);
                    
                }

                else
                {

                }
            }

        }

        public void UpdateHidden(char c, int index)
        {
            HiddenWord[index] = c;            
            string currword = string.Join("",HiddenWord);
            string winningword = string.Join("",WordAsArray);
            Updatelbl();
            if (CheckForWin(currword, winningword) == true)
            {
                lblWord.Content = $"You Win, Congratulations. It took you {intNumberOfGuesses} attempts";
            } 

        }

        public bool CheckForWin(string e, string f) {

            if (e.Equals(f))
            {
                return true;
            }

            else
            {
                return false;
            }
        }


       public void Updatelbl()
        {

            lblWord.Content = string.Join(" ",HiddenWord);

        }

        public void Window_TextInput(object sender, TextCompositionEventArgs e)
        {
            var gs = e.TextComposition.Text;
            char Guess = gs[0];

            if (GuessedLetters.Contains(Guess))
            {

                lblWord.Content = "GUESSED ALREADY";

            }
            else
            {
                CheckGuess(Guess);
                GuessedLetters.Add(Guess);
                intNumberOfGuesses++;

            }
        }
    }

}

