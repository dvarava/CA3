/* Name:            CA3
 * Author:          Deniels Varava
 * Date Created :   03/04/23
 * Purpose:         Ships
 * Modified By: 
 */

using static System.Console;

namespace CA3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = GetChoice();
            WriteLine(choice);

            string path = @"../../../faminefile.csv";

            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');


                    WriteLine($"{fields[0]}");
                }
            }
            catch (FileNotFoundException)
            {
                WriteLine($"File not found: {path}");
            }
            catch (IOException)
            {
                WriteLine($"Error reading file: {path}");
            }
            catch (FormatException myError)
            {
                WriteLine(myError.Message);
            }
        }

        static int GetChoice()
        {
            int choice = 0;

            while (true)
            {
                WriteLine("Main Menu\n" +
                    "1. Ship Reports\n" +
                    "2. Occupation Report\n" +
                    "3. Age Report\n" +
                    "4. Exit\n");

                Write("Enter Choice: ");
                string choiceInput = ReadLine();

                if (int.TryParse(choiceInput, out choice))
                {
                    if (choice > 0 && choice <= 4)
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("Wrong option! Try again\n");
                    }
                }
                else
                {
                    WriteLine("Enter a number! Try again\n");
                }
            }

            return choice;
        }
    }
}