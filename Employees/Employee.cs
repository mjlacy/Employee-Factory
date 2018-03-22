using System;

namespace Employees
{
    public abstract class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string SocialSecurityNumber { get; private set; }

        // three-parameter constructor
        public Employee(string firstName, string lastName,
           string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public void Menu()
        {
            string input;
            do
            {
                Console.WriteLine("|========================================|");
                Console.WriteLine("|           FIRST NATIONAL BANK          |");
                Console.WriteLine("|**************Menu Options**************|");
                Console.WriteLine("|________________________________________|");
                Console.WriteLine("|     Press 1 To Calculate Gross Pay     |");
                Console.WriteLine("|        Press 2 To Calculate Tax        |");
                Console.WriteLine("|      Press 3 To Calculate Net Pay      |");
                Console.WriteLine("| Press 4 To Select a Different Employee |");
                Console.WriteLine("|________________________________________|");
                Console.WriteLine("|      Please Make Selection Now...      |");
                Console.WriteLine("|========================================|");
                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                if (input == "1")
                {
                    CalcGrossPay();
                }
                else if (input == "2")
                {
                    CalcTax();
                }
                else if (input == "3")
                {
                    CalcNetPay();
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose 1, 2, 3, or 4");
                }
                Console.WriteLine();
            } while (input != "4");
        }

        public abstract void CalcGrossPay();

        public abstract void CalcTax();

        public abstract void CalcNetPay();

        // abstract method overridden by derived classes
        public abstract decimal Earnings(); // no implementation here
    }
}
