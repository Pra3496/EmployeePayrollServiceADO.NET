namespace PayrollServiceADO
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PayrollServiceModel PayrollServiceModel = new PayrollServiceModel()
            {
                EmployeeName = "Prakash",
                PhoneNumber = "12345",
                Address = "dwfbwufbwu",
                Department = "UI-Development",
                Gender = 'M',
                BasicPay = 25085.63f,
                Deduction = 5963.6f,
                TaxablePay = 1123.32f,
                Tax = 659.56f,
                NetPay = 650098.63f,
                StartDate = DateTime.Now,
                City = "Nagpur",
                Country = "India"
              
            };


            EmployeePayrollService employeePayrollService = new EmployeePayrollService();
            bool flag = true;
            string name = null;

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("\nWell-Come to employeePayrollService with MS-SQL\n");
                Console.WriteLine("\t\t-:OPTIONS:-\n");
                Console.WriteLine("1 : ADDING Data to employeePayrollService");
                Console.WriteLine("2 : DISPLAY Data From employeePayrollService");
                Console.WriteLine("3 : UPDATE Data From employeePayrollService");
                Console.WriteLine("4 : DISPLAY SELECTED Data From employeePayrollService");
                Console.WriteLine("5 : DELETE SELECTED Data From employeePayrollService");
                Console.WriteLine("0 : EXIT\n");
                Console.Write("Enter option : ");
                int opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("\n---------{ ADDING Data to employeePayrollService }---------\n");
                        employeePayrollService.AddingNewValue(PayrollServiceModel);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("\n---------{ DISPLAY Data From employeePayrollService }---------\n");
                        employeePayrollService.GetAllDataFromDataBase();
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("\n---------{ UPDATE Data From AddressBook }---------\n");
                        Console.Write("\nEnter the Name : ");
                        string EmployeeName = Convert.ToString(Console.ReadLine());
                        Console.Write("\nEnter the Department(Replace by) : ");
                        string Department = Convert.ToString(Console.ReadLine());
                        employeePayrollService.UpdateDatafromDatabase(EmployeeName, Department);
                        Console.Write("Press any key..."); 
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("\n---------{ DISPLAY SELECTED Data From employeePayrollService }---------");
                        Console.Write("\nEnter the Name : ");
                        name = Convert.ToString(Console.ReadLine());
                        employeePayrollService.GetSelectedDataFromDataBase(name);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("\n---------{ DELETE Data From employeePayrollService }---------\n");
                        Console.Write("\nEnter the Name : ");
                        name = Convert.ToString(Console.ReadLine());
                        employeePayrollService.DeleteDatafromDatabase(name);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;


                    case 0:
                        flag = false;
                        break;

                    default: Console.WriteLine("Please enter proper options"); break;
                }
            }

        }
    }
}