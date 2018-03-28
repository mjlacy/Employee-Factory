using System;

namespace Employees
{
    [Serializable]
    public abstract class Employee
    {
        /*********************
         Attributes
        *********************/
        public decimal rate = 30.0M;
        public float taxrate = 0.2f;
        public int hours = 45;
        public float gross = 0.0f;
        public float tax = 0.0f;
        public float net = 0.0f;
        public float net_percent = 0.0f;
        //End Attributes

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
                Console.WriteLine("|         Employee Payroll System        |");
                Console.WriteLine("|**************Menu Options**************|");
                Console.WriteLine("|________________________________________|");
                Console.WriteLine("| Press 1 To Calculate Gross Pay         |");
                Console.WriteLine("| Press 2 To Calculate Tax               |");
                Console.WriteLine("| Press 3 To Calculate Net Pay           |");
                Console.WriteLine("| Press 4 To Calculate Net Percent       |");
                Console.WriteLine("| Press 5 To Display Employee            |");
                Console.WriteLine("| Press A To Do all of the above         |");
                Console.WriteLine("| Press 6 To Return to Main Menu         |");
                Console.WriteLine("|________________________________________|");
                Console.WriteLine("|      Please Make Selection Now...      |");
                Console.WriteLine("|========================================|");
                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                if (input == "1")
                {
                    gross = CalcGrossPay();
                    Console.WriteLine($"Gross: {gross:C}");
                }
                else if (input == "2")
                {
                    tax = CalcTax();
                    Console.WriteLine($"Tax: {tax:C}");
                }
                else if (input == "3")
                {
                    net = CalcNetPay();
                    Console.WriteLine($"Net: {net:C}");
                }
                else if (input == "4")
                {
                    net_percent = CalcNetperc();
                    Console.WriteLine($"Net Percentage: {net_percent}");
                }
                else if (input == "5")
                {
                    DisplayEmployee();
                }
                else if (input == "6")
                {
                    //do nothing
                }
                else if (input == "a" || input == "A")
                {
                    gross = CalcGrossPay();
                    tax = CalcTax();
                    net = CalcNetPay();
                    net_percent = CalcNetperc();
                    DisplayEmployee();
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a valid option");
                }
                Console.WriteLine();
            } while (input != "6");
        }

        public abstract float CalcGrossPay();

        public float CalcTax()
        {
            return gross * taxrate;
        }

        public float CalcNetPay()
        {
            return gross - tax;
        }

        public float CalcNetperc()
        {
             return (net / gross) * 100;
        }

        public void DisplayEmployee()
        {
            Console.WriteLine("First: " + FirstName);
            Console.WriteLine("Last: " + LastName);
            Console.WriteLine("SSN: " + SocialSecurityNumber.Insert(5, "-").Insert(3, "-"));
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Rate: " + rate);
            Console.WriteLine($"Gross: {gross:C}");
            Console.WriteLine($"Net: {net:C}");
            Console.WriteLine("Net%: " + net_percent + "%");
        }
    }
}