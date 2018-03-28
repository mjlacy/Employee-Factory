using System;

namespace Employees
{
    class SalariedEmployee : Employee
    {
        private decimal grossSalary;

        // four-parameter constructor
        public SalariedEmployee(string firstName, string lastName,
           string socialSecurityNumber, decimal grossSalary)
           : base(firstName, lastName, socialSecurityNumber)
        {
            GrossSalary = grossSalary; // validate salary via property
        }

        // property that gets and sets salaried employee's salary
        public decimal GrossSalary
        {
            get
            {
                return grossSalary;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(GrossSalary)} must be >= 0");
                }

                grossSalary = value;
            }
        }

        public override void CalcGrossPay()
        {
            gross = (float)GrossSalary;
            
        }
        public override void displayEmployee()
        {

            Console.WriteLine("First: " + FirstName);
            Console.WriteLine("Last: " + LastName);
            Console.WriteLine("SSN: " + SocialSecurityNumber);
            Console.WriteLine("Type: Salaried" );
            Console.WriteLine("Gross: " + gross);
            Console.WriteLine("Net: " + net);
            Console.WriteLine("Net%: " + net_percent + "%");
        }

    }
}
