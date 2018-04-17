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
            Rate = hourlyWage; // validate hourly wage 
            Hours = hoursWorked; // validate hours worked 
        }

        public override decimal CalcGrossPay()
        {
            if (Hours <= 40) // no overtime                          
            {
                return (Rate * Hours);
            }
            else
            {
                return (40 * Rate) + ((Hours - 40) * Rate * 1.5M);
            }
        }
    }
}