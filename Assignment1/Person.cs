using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1
{
    public class Person
    {
        
            public string Name;
            public string City;
            public int Age;



        public Person ReadPerson()
        {
            Console.Write("Enter your name: ");
            Name = Console.ReadLine();
            //Console.WriteLine($"Welcome {Name}!");
            Console.Write("Enter your city: ");
            City = Console.ReadLine();
            Console.Write("Enter your age: ");
            Age = int.Parse(Console.ReadLine());

            return new Person();
        }

            public void DisplayPerson(Person p)
            {
                Console.WriteLine($"Name: {p.Name}\nCity: {p.City}\nAage: {p.Age}");
            }

        public void WritePerson(Person p, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
           
            writer.WriteLine(Name);
            writer.WriteLine(City);
            writer.WriteLine(Age);
            Console.WriteLine();
            writer.Close();
        }

        public Person ReadPerson(string filename)
        {
            StreamReader reader = new StreamReader(filename);


            string[] lines = File.ReadAllLines(filename);

            Person person = new Person()
            {
                Name = lines[0],
                City = lines[1],
                Age = int.Parse(lines[2])
            };

            reader.Close();
            


            
            
            return person;
        }



    }
}
