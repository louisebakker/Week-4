namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        public void Start()
        {
            Person person = new Person();



            Console.Write("Enter your name: ");
            string inputName = Console.ReadLine();
            string filename = $"{inputName}.txt";
            if (File.Exists(filename))
            {
                Console.WriteLine($"nice to see you again {inputName}!");
                Console.WriteLine("We have the following information about you:");
                person.DisplayPerson(person.ReadPerson(filename));
            }
            else
            {
                Console.WriteLine($"Welcome {inputName}!");
                person.ReadPerson();
                person.WritePerson(person, filename);
                Console.WriteLine("Your date is written to file.");
            }

            
            
            //person.DisplayPerson(person);
           

  
            

        }

        



    }
}
