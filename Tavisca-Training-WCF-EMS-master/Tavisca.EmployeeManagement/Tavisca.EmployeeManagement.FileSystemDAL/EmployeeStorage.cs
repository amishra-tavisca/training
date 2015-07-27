
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data;
using System.Data.SqlClient;
namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {
      
        public Model.Employee Save(Model.Employee employee)
        {
           
            try
            {

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO employees (Id , Title, FirstName, LastName,Email,Phone) VALUES (@0, @1, @2, @3,@4,@5)", conn);

                    insertCommand.Parameters.Add(new SqlParameter("0", employee.Id));
                    insertCommand.Parameters.Add(new SqlParameter("1", employee.Title));
                    insertCommand.Parameters.Add(new SqlParameter("2", employee.FirstName));
                    insertCommand.Parameters.Add(new SqlParameter("3", employee.LastName));
                    insertCommand.Parameters.Add(new SqlParameter("4", employee.Email));
                    insertCommand.Parameters.Add(new SqlParameter("5", employee.Phone));
                    insertCommand.ExecuteNonQuery();
                    conn.Close();
                }
                

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
            return employee;
        }



        public Model.Employee Get(string employeeId)
        {
            try
            {
                Model.Employee employee = new Model.Employee();
                using (SqlConnection conn = new SqlConnection())
                {                  
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand getCommand = new SqlCommand("INSERT INTO employees (Id , Title, FirstName, LastName,Email,Phone) VALUES (@0, @1, @2, @3,@4,@5)", conn);

                    // In the command, there are some parameters denoted by @, you can 
                    // change their value on a condition, in my code they're hardcoded.
                    using (SqlDataReader reader=getCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            employee.Id=reader[0].ToString();
                            employee.Title=reader[1].ToString();
                            employee.FirstName=reader[2].ToString();
                            employee.LastName=reader[3].ToString();
                            employee.Email=reader[4].ToString();
                            employee.Phone=reader[5].ToString();
                        }
                    }
                    conn.Close();
                    return employee;
                }

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public List<Model.Employee> GetAll()
        {
            try
            {
                List<Model.Employee> employeeList = new List<Model.Employee>();
                Model.Employee employee = new Model.Employee();
                using (SqlConnection conn = new SqlConnection())
                {
                    // Create the connectionString
                    // Trusted_Connection is used to denote the connection uses Windows Authentication
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand getCommand = new SqlCommand("INSERT INTO employees (Id , Title, FirstName, LastName,Email,Phone) VALUES (@0, @1, @2, @3,@4,@5)", conn);

                    // In the command, there are some parameters denoted by @, you can 
                    // change their value on a condition, in my code they're hardcoded.
                    using (SqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee.Id = reader[0].ToString();
                            employee.Title = reader[1].ToString();
                            employee.FirstName = reader[2].ToString();
                            employee.LastName = reader[3].ToString();
                            employee.Email = reader[4].ToString();
                            employee.Phone = reader[5].ToString();
                            employeeList.Add(employee);
                        }
                    }
                    conn.Close();
                    return employeeList;
                }

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
    }
}









