using System;

namespace Employees
{
    [Serializable]
    public abstract class Employee
    {
        /*********************
         Attributes
        *********************/
        public decimal Rate { get; set; } = 30.0M;
        public float TaxRate { get; set; } = 0.2f;
        private int hours = 45;
        public decimal Gross { get; set; } = 0.0m;
        public decimal Tax { get; set; } = 0.0m;
        public decimal Net { get; set; } = 0.0m;
        public float NetPercent { get; set; } = 0.0f;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < 0 || value > 168) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Hours)} must be >= 0 and <= 168");
                }
                hours = value;
            }
        }

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
                    Gross = CalcGrossPay();
                    Console.WriteLine($"Gross: {Gross:C}");
                }
                else if (input == "2")
                {
                    Tax = CalcTax();
                    Console.WriteLine($"Tax: {Tax:C}");
                }
                else if (input == "3")
                {
                    Net = CalcNetPay();
                    Console.WriteLine($"Net: {Net:C}");
                }
                else if (input == "4")
                {
                    NetPercent = CalcNetperc();
                    Console.WriteLine($"Net Percentage: {NetPercent}");
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
                    Gross = CalcGrossPay();
                    Tax = CalcTax();
                    Net = CalcNetPay();
                    NetPercent = CalcNetperc();
                    DisplayEmployee();
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a valid option");
                }
                Console.WriteLine();
            } while (input != "6");
        }

        public abstract decimal CalcGrossPay();

        public decimal CalcTax()
        {
            return Gross * (decimal)TaxRate;
        }

        public decimal CalcNetPay()
        {
            return Gross - Tax;
        }

        public float CalcNetperc()
        {
             return (float)(Net / Gross) * 100;
        }


        public void DisplayEmployee()
        {
            Console.WriteLine("First: " + FirstName);
            Console.WriteLine("Last: " + LastName);
            Console.WriteLine("SSN: " + SocialSecurityNumber.Insert(5, "-").Insert(3, "-"));
            Console.WriteLine("Account Type: " + GetType().ToString().Substring(10).Replace(GetType().ToString().Substring(GetType().ToString().Length -8), " Employee"));
            if(GetType().ToString() == "Employees.HourlyEmployee")
            {
                Console.WriteLine("Hours: " + hours);
                Console.WriteLine($"Rate: {Rate:C}");
            }
            Console.WriteLine($"Tax Rate: {TaxRate * 100}%");
            Console.WriteLine($"Gross: {Gross:C}");
            Console.WriteLine($"Tax: {Tax:C}");
            Console.WriteLine($"Net: {Net:C}");
            Console.WriteLine("Net%: " + NetPercent + "%");
        }
    }
}