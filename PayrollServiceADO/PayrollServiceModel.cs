using System;

namespace PayrollServiceADO
{
    public class PayrollServiceModel
    {
       
        public int PersonID { get; set; }
        public string EmployeeName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public char Gender { get; set; }

        public double BasicPay { get; set; }

        public double Deduction { get; set;}

        public double TaxablePay { get; set;}

        public double Tax { get; set; }

        public double NetPay { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime StartDate { get; set; }
    }
}
