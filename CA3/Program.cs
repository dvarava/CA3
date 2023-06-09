﻿/* Name:            CA3
 * Author:          Deniels Varava
 * Date Created :   03/04/23
 * Purpose:         Allow the user to explore passenger data from ships who sailed to New York during the 1800s
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
        static bool exceptionCaught = false;
        static void Main(string[] args)
        {
            List<Passenger> passengers = AddInfo();

            if (!exceptionCaught)
            {
                WriteLine("---A program to to allow the user to explore passenger data from ships who sailed to New York during the 1800s---");

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
        } // end of the Main method

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
                DateOnly date;

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

                    try
                    {
                        date = DateOnly.ParseExact(data[i, 9], "MM/dd/yyyy", null);
                    }
                    catch (FormatException)
                    {
                        WriteLine($"{i} line has date ({data[i,9]}) in incorrect format");
                        continue;
                    }

                    Passenger passenger = new Passenger(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4], data[i, 5], data[i, 6], data[i, 7], data[i, 8], date);
                    passengers.Add(passenger);
                }
            }
            catch (FileNotFoundException)
            {
                WriteLine($"File not found: {path}");
                exceptionCaught = true;
            }
            catch (IOException)
            {
                WriteLine($"Error reading file: {path}");
                exceptionCaught = true;
            }
            catch (FormatException myError)
            {
                WriteLine(myError.Message);
                exceptionCaught = true;
            }

            return passengers;
        } // end of the AddInfo method

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
        } // end of the GetChoice method
    }
}