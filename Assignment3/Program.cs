using System.Globalization;

namespace Assignment3
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
            

            Console.Write("Enter a word (to search): ");
            string searchWord = Console.ReadLine();


            //loop through lines
            StreamReader reader = new StreamReader(filename);
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }




            /*foreach (string line in lines)
            {
                if (WordInLine(line, searchWord) == true)
                {
                    Console.WriteLine(line);
                }
            }*/

            

        }


        bool WordInLine(string line, string word)
        {
            bool wordIsInLine = false;
            string[] wordsInLine = File.ReadAllLines(line);
            foreach (string words in wordsInLine)
            {
                if (words == word)
                {
                    wordIsInLine = true;
                }
                
            }



            return wordIsInLine;
        }
    }
}