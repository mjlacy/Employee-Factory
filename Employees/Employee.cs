using System;

namespace Employees
{
    public abstract class Employee
    {
        /*********************
         Attributes
        *********************/
        public float rate = 30.0f;
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
                Console.WriteLine("| Press a To Do all of the above         |");
                Console.WriteLine("| Press 6 To Select a Different Employee |");
                Console.WriteLine("|________________________________________|");
                Console.WriteLine("|      Please Make Selection Now...      |");
                Console.WriteLine("|========================================|");
                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                if (input == "1")
                {
                    CalcGrossPay();
                    Console.WriteLine("Calculated!");
                }
                else if (input == "2")
                {
                    CalcTax();
                    Console.WriteLine("Calculated!");
                }
                else if (input == "3")
                {
                    CalcNetPay();
                    Console.WriteLine("Calculated!");
                }
                else if (input == "4")
                {
                    CalcNetperc();
                    Console.WriteLine("Calculated!");
                }
                else if (input == "5")
                {
                    displayEmployee();
                }
                else if (input == "6")
                {
                    //do nothing
                }
                else if (input == "a")
                {
                    CalcGrossPay();
                    CalcTax();
                    CalcNetPay();
                    CalcNetperc();
                    displayEmployee();
                }

                else
                {
                    Console.WriteLine("Invalid input, please choose a valid option");
                }
                Console.WriteLine();
            } while (input != "6");
        }

        public virtual void CalcGrossPay()
        {
           gross = rate * hours;
            
        }

        public virtual void CalcTax()
        {
            tax = gross * taxrate;
            
        }

        public virtual void CalcNetPay()
        {
            net = gross - tax;
            
        }

        public virtual void CalcNetperc()
        {
            net_percent = (net / gross) * 100;
            
        }


        public virtual void displayEmployee()
        {

            Console.WriteLine("First: " + FirstName);
            Console.WriteLine("Last: " + LastName);
            Console.WriteLine("SSN: " + SocialSecurityNumber);
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Rate: " + rate);
            Console.WriteLine("Gross: " + gross);
            Console.WriteLine("Net: " + net);
            Console.WriteLine("Net%: " + net_percent + "%");
        }



    }
}
