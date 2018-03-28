using System;

namespace Employees
{
    [Serializable]
    class HourlyEmployee : Employee
    {
        // five-parameter constructor
        public HourlyEmployee(string firstName, string lastName, string socialSecurityNumber,
           decimal hourlyWage,
           int hoursWorked)
           : base(firstName, lastName, socialSecurityNumber)
        {
            rate = hourlyWage; // validate hourly wage 
            Hours = hoursWorked; // validate hours worked 
        }

        // property that gets and sets hourly employee's hours
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

        public override float CalcGrossPay()
        {
            if (Hours <= 40) // no overtime                          
            {
                return (float)(rate * Hours);
            }
            else
            {
                return (float)((40 * rate) + ((Hours - 40) * rate * 1.5M));
            }
        }
    }
}