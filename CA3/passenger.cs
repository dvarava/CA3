using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CA3
{
    class Passenger
    {
        private string _firstName;
        private string _lastName;
        private string _age;
        private string _sex;
        private string _occupation;
        private string _country;
        private string _destination;
        private string _port;
        private string _idNumber;
        private DateOnly _arrivalDate;

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName;} set { _lastName = value; } }
        public string Age { get { return _age;} set { _age = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string Country { get { return _country;} set { _country = value; } }
        public string Destination { get { return _destination;} set { _destination = value; } }
        public string Port { get { return _port;} set { _port = value; } }
        public string IdNumber { get { return _idNumber;} set { _idNumber = value; } }
        public DateOnly ArrivalDate { get { return _arrivalDate;} set { _arrivalDate = value;} }

        public Passenger (string firstName, string lastName, string age, string sex, string occupation, string country, string destination, string port, string idNumber, DateOnly arrivalDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
            Occupation = occupation;
            Country = country;
            Destination = destination;
            Port = port;
            IdNumber = idNumber;
            ArrivalDate = arrivalDate;
        }

        public static void ShipReport(List<Passenger> passengers)
        {
            List<string> shipNumbers = new List<string>();
            string leavingStation = "";
            DateOnly arrivalDate;
            int passengerCount = 0, choice;

            for (int i = 0; i < passengers.Count; i++)
            {
                if (!shipNumbers.Contains(passengers[i].IdNumber))
                {
                    shipNumbers.Add(passengers[i].IdNumber);
                }
            }

            for (int i = 0; i < shipNumbers.Count; i++)
            {
                WriteLine($"{i + 1}. {shipNumbers[i]}");
            }

            while (true)
            {
                Write("Enter Choice: ");
                string choiceInput = ReadLine();

                if (int.TryParse(choiceInput, out choice))
                {
                    if (choice > 0 && choice <= shipNumbers.Count)
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

            for (int i = 0; i < passengers.Count; i++)
            {
                if (passengers[i].IdNumber == shipNumbers[choice - 1])
                {
                    leavingStation = passengers[i].Port;
                    arrivalDate = passengers[i].ArrivalDate;
                    passengerCount++;
                }
            }

            WriteLine("\n\t*** Ship Report ***");
            WriteLine($"{shipNumbers[choice - 1]} : leaving from {leavingStation} Arrived : {arrivalDate} with {passengerCount} passengers");

            for (int i = 0; i < passengers.Count; i++)
            {
                if (passengers[i].IdNumber == shipNumbers[choice - 1])
                {
                    WriteLine($"First Name {passengers[i].FirstName} : Last Name {passengers[i].LastName}");
                }
            }
        } // end of the ShipReport method

        public static void OccupationReport(List<Passenger> passengers)
        {
            List<string> occupationTitles = new List<string>();

            for (int i = 1; i < passengers.Count; i++)
            {
                if (!occupationTitles.Contains(passengers[i].Occupation))
                {
                    occupationTitles.Add(passengers[i].Occupation);
                }
            }

            int[] eachOccupationCount = new int[occupationTitles.Count];

            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < occupationTitles.Count; j++)
                {
                    if (passengers[i].Occupation == occupationTitles[j])
                    {
                        eachOccupationCount[j]++;
                    }
                }
            }

            WriteLine("\n\t*** Occupation Report ***");
            for (int i = 0; i < occupationTitles.Count; i++)
            {
                WriteLine($"{i + 1}. {occupationTitles[i]} : {eachOccupationCount[i]}");
            }
        } // end of the Occupation Report method

        public static void AgeReport(List<Passenger> passengers)
        {
            const string TABLE = "{0,-20}{1,30}";
            int infants = 0, children = 0, teenagers = 0, youngAdults = 0, adults = 0, olderAdults = 0, unknown = 0;

            for (int i = 0; i < passengers.Count; i++)
            {
                string ageStr = "";
                int age;

                foreach (char c in passengers[i].Age)
                {
                    if (Char.IsDigit(c))
                    {
                        ageStr += c;
                    }
                }

                if (int.TryParse(ageStr, out age))
                {
                    if (passengers[i].Age.Contains("Infant in months"))
                    {
                        infants++;
                    }
                    else if (age > 0 && age < 13)
                    {
                        children++;
                    }
                    else if (age >= 12 && age < 20)
                    {
                        teenagers++;
                    }
                    else if (age >= 20 && age < 30)
                    {
                        youngAdults++;
                    }
                    else if (age >= 30 && age < 50)
                    {
                        adults++;
                    }
                    else
                    {
                        olderAdults++;
                    }
                }
                else
                {
                    unknown++;
                }
            }

            WriteLine("\n\t*** Age Report ***");
            WriteLine(TABLE, "Infants(<1 year) :", infants);
            WriteLine(TABLE, "Children(1-12) :", children);
            WriteLine(TABLE, "Teenagers(13-19) :", teenagers);
            WriteLine(TABLE, "Young adults(20-29) :", youngAdults);
            WriteLine(TABLE, "Adults(30+ years) :", adults);
            WriteLine(TABLE, "Older Adults(50+) :", olderAdults);
            WriteLine(TABLE, "Unknown :", unknown);
        } // end of the AgeReport method
    }
}
