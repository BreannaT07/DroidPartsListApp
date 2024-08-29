using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace DroidPartsListApp
{
    internal class Program
    {
        static string filePath = "droidpartslist.txt";
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Droid Parts Lists");
                Console.WriteLine("1. View Droid Part List");
                Console.WriteLine("2. Add Part");
                Console.WriteLine("3. Delete Part");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewPartsLists();
                        break;
                    case "2":
                        AddPart();
                        break;
                    case "3":
                        DeletePart();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invaild Choice.");
                        Console.ReadKey();
                        break;
                }

            }

        }
        static void ViewPartsLists()
        {
            Console.Clear();
            Console.WriteLine("Droid Parts Lists:");

            if (File.Exists(filePath))
            {
                string[] parts = File.ReadAllLines(filePath);
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {parts[i]}");
                }
            }
            else
            {
                Console.WriteLine("This droid parts list is empty.");
            }

            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();

        }
        static void AddPart()
        {
            Console.Clear();
            Console.Write("Enter the part to add: ");
            string newPart = Console.ReadLine();

            if (!string.IsNullOrEmpty(newPart))
            {
                File.AppendAllText(filePath, newPart + Environment.NewLine);
                Console.WriteLine($"{newPart} has been added to the droid parts list.");
            }
            else
            {
                Console.WriteLine("Part name cannot be empty.");
            }

            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();

        }
        static void DeletePart()
        {
            Console.Clear();
            Console.WriteLine("Droid Parts List:");

            if (File.Exists(filePath))
            {
                string[] parts = File.ReadAllLines(filePath);

                for (int i = 0; i < parts.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {parts[i]}");
                }

                Console.Write("Enter the number of the parts to delete: ");
                //Added a side note because I kept typing out the word and not the number lol
                Console.WriteLine("\nNote: Type out the number and not the word");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= parts.Length)
                {
                    List<string> updatedList = new List<string>(parts);
                    string removedPart = updatedList[index - 1];
                    updatedList.RemoveAt(index - 1);
                    File.WriteAllLines(filePath, updatedList);
                    Console.WriteLine($"{removedPart} has been deleted from the droid parts list.");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            else
            {
                Console.WriteLine("The droid parts list is empty.");
            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();

        }
    }
}