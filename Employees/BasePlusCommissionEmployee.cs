using System;

namespace Employees
{
    [Serializable]
    class BasePlusCommissionEmployee : CommissionEmployee
    {
        private decimal baseSalary;

        // six-parameter constructor
        public BasePlusCommissionEmployee(string firstName, string lastName,
           string socialSecurityNumber, decimal grossSales,
           decimal commissionRate, decimal baseSalary)
           : base(firstName, lastName, socialSecurityNumber,
                grossSales, commissionRate)
        {
            BaseSalary = baseSalary;
        }

        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(BaseSalary)} must be >= 0");
                }

                baseSalary = value;
            }
        }

        public override decimal CalcGrossPay()
        {
            return BaseSalary + base.CalcGrossPay();
        }
    }
}
