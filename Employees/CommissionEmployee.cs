using System;

namespace Employees
{
    class CommissionEmployee : Employee
    {
        private decimal grossSales; // gross weekly sales
        private decimal commissionRate; // commission percentage

        // five-parameter constructor
        public CommissionEmployee(string firstName, string lastName,
           string socialSecurityNumber, decimal grossSales,
           decimal commissionRate)
           : base(firstName, lastName, socialSecurityNumber)
        {
            GrossSales = grossSales; // validates gross sales
            CommissionRate = commissionRate; // validates commission rate
        }

        // property that gets and sets commission employee's gross sales
        public decimal GrossSales
        {
            get
            {
                return grossSales;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(GrossSales)} must be >= 0");
                }

                grossSales = value;
            }
        }

        // property that gets and sets commission employee's commission rate
        public decimal CommissionRate
        {
            get
            {
                return commissionRate;
            }
            set
            {
                if (value <= 0 || value >= 1) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(CommissionRate)} must be > 0 and < 1");
                }

                commissionRate = value;
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
        public override decimal Earnings() => CommissionRate * GrossSales;
    }
}
