namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            //const int totalAttempts = 8;
            int attempts = 8;
            Random random = new Random();
            List<string> words = new List<string>();
            string selectedWord = "";
            bool isGuessed = false;

           
            filename = ("..\\..\\..\\woorden.txt");
            HangmanGame hangman = new HangmanGame();
            words = ListOfWords(filename);
            string secretWord = SelectWord(words);
            hangman.Init(secretWord);
            //Console.WriteLine($"The secret word is: {hangman.secretWord}");
            //Console.WriteLine($"The guessed word is: {hangman.guessedWord}");


            if (PlayHangman(hangman))
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word({hangman.secretWord})");
            }




            List<string> ListOfWords(string filename)
            {
                List<string> words = new List<string>();
                StreamReader reader = new StreamReader(filename);
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    words.Add(line);
                    
                }
                reader.Close();

                return words;
            }



           /* void DisplayFile(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                reader.Close();
            }

           /* List<string> ListOfWords()
            {
                List<string> words = new List<string>();

                words.Add("airplane");
                words.Add("kitchen");
                words.Add("building");
                words.Add("incredible");
                words.Add("funny");
                words.Add("trainstation");
                words.Add("neighbour");
                words.Add("different");
                words.Add("department");
                words.Add("planet");
                words.Add("presentation");
                words.Add("embarrassment");
                words.Add("integration");
                words.Add("scenario");
                words.Add("discount");
                words.Add("management");
                words.Add("understanding");
                words.Add("registration");
                words.Add("security");
                words.Add("language");

                return words;
            }*/


            string SelectWord(List<string> words)
            {
                
               int index = random.Next(words.Count);
               
               while (words[index].Length < 3)
               {
                    index = random.Next(words.Count);
               };

                return words[index];
            }

            bool PlayHangman(HangmanGame hangman)
            {
                List<char> enteredLetters = new List<char>();
                List<char> blacklistLetters = new List<char>();


                do
                {

                    DisplayWord(hangman.guessedWord);
                    Console.WriteLine();

                    char inputLetter = ReadLetter(blacklistLetters);

                    enteredLetters.Add(inputLetter);

                    DisplayLetters(enteredLetters);

                    Console.WriteLine();
                    if (hangman.ContainsLetter(inputLetter))
                    {

                        hangman.ProcessLetter(inputLetter);
                        DisplayWord(hangman.guessedWord);
                    }
                    else
                    {

                        blacklistLetters.Add(inputLetter);
                        //ReadLetter(blacklistLetters);
                        attempts--;

                    }

                    Console.Write($"Attempts left: {attempts}\n");
                    Console.WriteLine();



                } while ((attempts > 0) && !hangman.IsGuessed());



                return (hangman.IsGuessed());
            }

            void DisplayWord(string word)
            {
                char[] wordLetters = word.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write($"{wordLetters[i]} ");

                }
                Console.WriteLine();
            }

            void DisplayLetters(List<char> letters)
            {
                string enteredLettersDisplayed = new string($"Entered letters: ");
                foreach (char letter in letters)
                {
                    enteredLettersDisplayed += ($"{letter} ");
                }
                Console.Write(enteredLettersDisplayed);
            }

            char ReadLetter(List<char> blacklistLetters)
            {
                char inputLetter;
                do
                {
                    Console.Write("Enter a letter: ");
                    inputLetter = char.Parse(Console.ReadLine());

                } while (blacklistLetters.Contains(inputLetter));
                return inputLetter;
            }









        }
    }
}