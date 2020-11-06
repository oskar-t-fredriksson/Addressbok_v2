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
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Kontaktboken!");
            ContactBookMenu();
            Console.WriteLine("> ");
            string command = Console.ReadLine();
            //C:\\Users\\oskar\\adressbok.txt
            do
            {
                if (command == "1")
                {
                    Writer();
                    break;

                }
                else if (command == "2")
                {
                    Remover();
                    break;

                }
                else if (command == "3")
                {
                    Reader();
                    break;
                }
            }
            while (command != "4");
        }
        //https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files code source
        static void ContactBookMenu()
        {
            Console.WriteLine("********Menyval********");
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Ta bort kontakt");
            Console.WriteLine("3. Visa kontakter");
            Console.WriteLine("4. Avsluta Kontaktboken");
            Console.WriteLine("***********************");
        }
        static void Writer()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            Console.WriteLine("Ange kontaktinfo(Namn, Adress, Telefon och Email): ");
            string addContactToTxt = Console.ReadLine() + Environment.NewLine + "\n";
            File.AppendAllText(path, addContactToTxt, Encoding.UTF8);
        }
        static void Remover()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            string removeTextFromTxt = Console.ReadLine() + Environment.NewLine;
            File.WriteAllText(path, removeTextFromTxt);
        }
        static void Reader()
        {
            string path = @"C:\\Users\\oskar\\adressbok.txt";
            string readContactsFromTxt = File.ReadAllText(path);
            Console.WriteLine($"{readContactsFromTxt}");
        }

    }
}
