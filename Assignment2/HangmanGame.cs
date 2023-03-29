using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;


        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            guessedWord = new string('.', secretWord.Length);
        }

        public bool ContainsLetter(char letter)
        {
            char[] secretWordLetters = secretWord.ToCharArray();



            return (secretWordLetters.Contains(letter));

        }


        public void ProcessLetter(char letter)
        {

            char[] secretWordLetters = secretWord.ToCharArray();
            char[] guessedWordLetters = guessedWord.ToCharArray();

            for (int i = 0; i < secretWordLetters.Length; i++)
            {
                if (letter == secretWordLetters[i])
                {
                    guessedWordLetters[i] = letter;
                }
            }

            guessedWord = new string(guessedWordLetters);

        }

        public bool IsGuessed()
        {


            return (secretWord == guessedWord);


        }
    }
}
