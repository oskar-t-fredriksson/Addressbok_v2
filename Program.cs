using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Addressbok_v2
{
    class Program
    {
        class ContactBook
        {
            public string name, address, phone, email;
            public ContactBook(string N, string A, string P, string E)
            {
                name = N; address = A; phone = P; email = E; 
            }
            public string Person()
            {
                return $"{name}, {address}, {phone}, {email}";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Kontaktboken!");
            string command;
            do
            {
                ContactBookMenu();
                Console.WriteLine("> ");
                command = Console.ReadLine();
                if (command == "1")
                {
                    Writer();                    
                }
                else if (command == "2")
                {
                    Remover();

                }
                else if (command == "3")
                {
                    Reader();
                }
            }
            while (command != "4");
        }
        static void ContactBookMenu()
        {
            Console.WriteLine("**********Menyval**********");
            Console.WriteLine("* 1. Lägg till kontakt    *");
            Console.WriteLine("* 2. Ta bort kontakt      *");
            Console.WriteLine("* 3. Visa kontakter       *");
            Console.WriteLine("* 4. Avsluta Kontaktboken *");
            Console.WriteLine("***************************");
        }
        //Source code for reading and writing text file https://stackoverflow.com/questions/9960064/append-in-a-text-file-in-c-sharp
        //Methode to add contact
        static void Writer()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            Console.WriteLine("Ange kontaktinfo, 'Namn', 'Adress', 'Telefon' och 'Email'");
            Console.WriteLine("Namn: ");
            string addNameToTxt = Console.ReadLine() + ",";
            File.AppendAllText(path, addNameToTxt, Encoding.UTF8);
            Console.WriteLine("Address: ");
            string addAdressToTxt = Console.ReadLine() + ",";
            File.AppendAllText(path, addAdressToTxt, Encoding.UTF8);
            Console.WriteLine("Telefonnummer: ");
            string addPhoneToTxt = Console.ReadLine() + ",";
            File.AppendAllText(path, addPhoneToTxt, Encoding.UTF8);
            Console.WriteLine("E-post: ");
            string addEmailToTxt = Console.ReadLine() + "\n";
            File.AppendAllText(path, addEmailToTxt, Encoding.UTF8);
            List<ContactBook> book = new List<ContactBook>();
            book.Add(new ContactBook(addNameToTxt, addAdressToTxt, addPhoneToTxt, addEmailToTxt));
        }
        //Methode to remove contact
        static void Remover()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            List<string> oldContacts = File.ReadAllLines(path).ToList();
            Console.Write("Vilket nummer vill du ta bort: ");
            int num = int.Parse(Console.ReadLine());
            oldContacts.RemoveAt(num - 1);
            //Found help from https://www.c-sharpcorner.com/blogs/how-to-remove-a-line-from-a-text-file-at-specific-location-in-c-sharp1
            File.WriteAllLines((path), oldContacts.ToArray());
        }
        //Methode to view all contacts
        static void Reader()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            List<string> oldContacts = File.ReadAllLines(path).ToList();
            for (int i = 0; i < oldContacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {oldContacts[i]}");
            }
        }
    }
}
