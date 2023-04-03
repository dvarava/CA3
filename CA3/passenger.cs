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
        private int _age;
        private string _sex;
        private string _occupation;
        private string _country;
        private string _destination;
        private string _port;
        private string _idNumber;
        private DateOnly _arrivalDate;

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName;} set { _lastName = value; } }
        public int Age { get { return _age;} set { _age = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string Country { get { return _country;} set { _country = value; } }
        public string Destination { get { return _destination;} set { _destination = value; } }
        public string Port { get { return _port;} set { _port = value; } }
        public string IdNumber { get { return _idNumber;} set { _idNumber = value; } }
        public DateOnly ArrivalDate { get { return _arrivalDate;} set { _arrivalDate = value;} }

        public Passenger () { }

        public Passenger (string firstName, string lastName, int age, string sex, string occupation, string country, string destination, string port, string idNumber, DateOnly arrivalDate)
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

        static void ReadFile()
        {
            string path = @"../../../faminefile.csv";

            try
            {
                string[] lines = File.ReadAllLines(path);

                WriteLine("Temperature Report\n");
                WriteLine("Date\t\tTemperature");

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
    }
}
