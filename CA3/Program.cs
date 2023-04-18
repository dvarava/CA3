/* Name:            CA3
 * Author:          Deniels Varava
 * Date Created :   03/04/23
 * Purpose:         Ships
 * Modified By: 
 */

using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Globalization;
using static System.Console;

namespace CA3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Passenger> passengers = AddInfo();

            while (true)
            {
                int choice = GetChoice();

                if (choice != 4)
                {
                    switch (choice)
                    {
                        case 1:
                            Passenger.ShipReport(passengers);
                            break;
                        case 2:
                            Passenger.OccupationReport(passengers);
                            break;
                        case 3:
                            Passenger.AgeReport(passengers);
                            break;
                    }
                }
                else
                {
                    WriteLine("*** End of program ***");
                    break;
                }
            }
        }

        static List<Passenger> AddInfo()
        {
            string path = @"../../../faminefiletoanalyse2.csv";
            string[,] data = null;
            List<Passenger> passengers = new List<Passenger>();

            try
            {
                string[] lines = File.ReadAllLines(path);
                int lineCount = lines.Count();
                data = new string[lineCount, 10];

                for (int i = 1; i < lineCount; i++)
                {
                    string[] columns = lines[i].Split(',');

                    if (columns.Length != 10)
                    {
                        WriteLine($"{i} line does not contain 10 values, but { columns.Length} value(s)");
                        continue;
                    }

                    for (int j = 0; j < columns.Length; j++)
                    {
                        data[i, j] = columns[j];
                    }

                    DateOnly date = DateOnly.ParseExact(data[i, 9], "MM/dd/yyyy", null);

                    Passenger passenger = new Passenger(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4], data[i, 5], data[i, 6], data[i, 7], data[i, 8], date);
                    passengers.Add(passenger);
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

            return passengers;
        }

        static int GetChoice()
        {
            int choice = 0;

            while (true)
            {
                WriteLine("\nMain Menu\n" +
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