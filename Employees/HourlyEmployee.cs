using System;

namespace Employees
{
    class HourlyEmployee : Employee
    {
        private decimal wage; // wage per hour
        private decimal hours; // hours worked for the week

        // five-parameter constructor
        public HourlyEmployee(string firstName, string lastName, string socialSecurityNumber,
           decimal hourlyWage,
           decimal hoursWorked)
           : base(firstName, lastName, socialSecurityNumber)
        {
            Wage = hourlyWage; // validate hourly wage 
            Hours = hoursWorked; // validate hours worked 
        }

        // property that gets and sets hourly employee's wage
        public decimal Wage
        {
            get
            {
                return wage;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(Wage)} must be >= 0");
                }

                wage = value;
            }
        }

        // property that gets and sets hourly employee's hours
        public decimal Hours
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

        public override void CalcGrossPay()
        {
            if (Hours <= 40) // no overtime                          
            {
                gross =  (float)(Wage * Hours);
            }
            else
            {
                gross = (float)((40 * Wage) + ((Hours - 40) * Wage * 1.5M));
            }

        }

        public override void displayEmployee()
        {

            Console.WriteLine("First: " + FirstName);
            Console.WriteLine("Last: " + LastName);
            Console.WriteLine("SSN: " + SocialSecurityNumber);
            Console.WriteLine("Type: Hourly");
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Rate: " + rate);
            Console.WriteLine("Gross: " + gross);
            Console.WriteLine("Net: " + net);
            Console.WriteLine("Net%: " + net_percent + "%");
        }

    }
}
