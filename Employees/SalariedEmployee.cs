using System;

namespace Employees
{
    class SalariedEmployee : Employee
    {
        private decimal weeklySalary;

        // four-parameter constructor
        public SalariedEmployee(string firstName, string lastName,
           string socialSecurityNumber, decimal weeklySalary)
           : base(firstName, lastName, socialSecurityNumber)
        {
            WeeklySalary = weeklySalary; // validate salary via property
        }

        // property that gets and sets salaried employee's salary
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(WeeklySalary)} must be >= 0");
                }

                weeklySalary = value;
            }
        }

        public override void CalcGrossPay()
        {

        }

        public override void CalcTax()
        {

        }

        public override void CalcNetPay()
        {

        }

        // calculate earnings; override abstract method Earnings in Employee
        public override decimal Earnings() => WeeklySalary;
    }
}
