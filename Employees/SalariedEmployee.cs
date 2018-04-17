using System;

namespace Employees
{
    [Serializable]
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

        public override decimal CalcGrossPay()
        {
            return GrossSalary;
        }
    }
}