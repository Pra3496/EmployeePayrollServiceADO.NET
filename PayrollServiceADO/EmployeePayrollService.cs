using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace PayrollServiceADO
{
    public class EmployeePayrollService
    {
        public static string connectionString = @"data source=.;initial catalog=Payroll_Service;trusted_connection=True;TrustServerCertificate=True";

        public void AddingNewValue(PayrollServiceModel payrollServiceModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spAddingNewDataToDB", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    
                    sqlCommand.Parameters.AddWithValue("@EmployeeName", payrollServiceModel.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", payrollServiceModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", payrollServiceModel.Address);
                    sqlCommand.Parameters.AddWithValue("@Department", payrollServiceModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Gender", payrollServiceModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", payrollServiceModel.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@Deduction", payrollServiceModel.Deduction);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", payrollServiceModel.TaxablePay);
                    sqlCommand.Parameters.AddWithValue("@Tax", payrollServiceModel.Tax);
                    sqlCommand.Parameters.AddWithValue("@NetPay", payrollServiceModel.NetPay);
                    sqlCommand.Parameters.AddWithValue("@StartDate", payrollServiceModel.StartDate);
                    sqlCommand.Parameters.AddWithValue("@City", payrollServiceModel.City);
                    sqlCommand.Parameters.AddWithValue("@Country", payrollServiceModel.Country);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result >= 1)
                    {
                        Console.WriteLine("\n\tNew Contact added Succesfuly\n");
                    }
                    else { Console.WriteLine("\n\tNot Added...!\n"); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Not Ready");
            }


        }

 	public void GetAllDataFromDataBase()
        {
            int iCnt = 0;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<PayrollServiceModel> payrollServiceList = new List<PayrollServiceModel>();

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spGetAllDataFromDataBase", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            PayrollServiceModel payrollServiceModel = new PayrollServiceModel();

                            payrollServiceModel.PersonID = sqlReader.GetInt32(0);
                            payrollServiceModel.EmployeeName = sqlReader.GetString(1);
                            payrollServiceModel.PhoneNumber = sqlReader.GetString(2);
                            payrollServiceModel.Address = sqlReader.GetString(3);
                            payrollServiceModel.Department = sqlReader.GetString(4);
                            payrollServiceModel.Gender = Convert.ToChar(sqlReader.GetString(5));
                            payrollServiceModel.BasicPay = sqlReader.GetDouble(6);
                            payrollServiceModel.Deduction = sqlReader.GetDouble(7);
                            payrollServiceModel.TaxablePay = sqlReader.GetDouble(8);
                            payrollServiceModel.Tax = sqlReader.GetDouble(9);
                            payrollServiceModel.NetPay = sqlReader.GetDouble(10);
                            payrollServiceModel.StartDate = sqlReader.GetDateTime(11);
                            payrollServiceModel.City = sqlReader.GetString(12);
                            payrollServiceModel.Country = sqlReader.GetString(13);


                            payrollServiceList.Add(payrollServiceModel);
                        }

                        foreach (PayrollServiceModel item in payrollServiceList)
                        {
                            Console.WriteLine("+++++++++++[ {0} ]+++++++++++\n", ++iCnt);

                            Console.WriteLine("Person ID    : " + item.PersonID);
                            Console.WriteLine("EmplyeeName  : " + item.EmployeeName);
                            Console.WriteLine("Phone Number : " + item.PhoneNumber);
                            Console.WriteLine("Address      : " + item.Address);
                            Console.WriteLine("Department   : " + item.Department);
                            Console.WriteLine("Gender       : " + item.Gender);
                            Console.WriteLine("Basic Pay    : " + item.BasicPay);
                            Console.WriteLine("Deduction    : " + item.Deduction);
                            Console.WriteLine("Taxable Pay  : " + item.TaxablePay);
                            Console.WriteLine("Tax          : " + item.Tax);
                            Console.WriteLine("Net Pay      : " + item.NetPay);
                            Console.WriteLine("Start Date   : " + item.StartDate);
                            Console.WriteLine("City         : " + item.City);
                            Console.WriteLine("Country      : " + item.Country);



                            Console.WriteLine("\n+++++++++++*+*+*+*++++++++++++\n");
                        }
                    }
                    else
                        Console.WriteLine("no data found in table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateDatafromDatabase(string EmployeeName, string Department)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            PayrollServiceModel payrollServiceModel = new PayrollServiceModel();
            payrollServiceModel.EmployeeName = EmployeeName;
            payrollServiceModel.Department = Department;
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spUpdateDataOfDataBase", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmployeeName",payrollServiceModel.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@Department",payrollServiceModel.Department);
                    int result = sqlCommand.ExecuteNonQuery();
                    

                    if (result >= 1)
                    {
                        Console.WriteLine("\n\tNew Contact Updated Succesfuly\n");
                    }
                    else { Console.WriteLine("\n\tNot Updated...!\n"); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }


        }

	

       
    }
}
