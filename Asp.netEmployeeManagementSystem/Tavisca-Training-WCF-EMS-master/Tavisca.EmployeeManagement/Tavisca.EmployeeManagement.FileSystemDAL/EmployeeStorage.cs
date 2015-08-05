

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
                    //SqlCommand insertCommand = new SqlCommand("EXECUTE InsertById @0, @1, @2, @3,@4,@5", conn);
                    SqlCommand insertCommand = new SqlCommand("EXECUTE InsertByIdProcedure  @1, @2, @3, @4, @5, @6", conn);

                    //insertCommand.Parameters.Add(new SqlParameter("0", employee.Id));
                    insertCommand.Parameters.Add(new SqlParameter("1", employee.Title));
                    insertCommand.Parameters.Add(new SqlParameter("2", employee.FirstName));
                    insertCommand.Parameters.Add(new SqlParameter("3", employee.LastName));
                    insertCommand.Parameters.Add(new SqlParameter("4", employee.Email));
                    insertCommand.Parameters.Add(new SqlParameter("5", employee.Phone));
                  //  insertCommand.Parameters.Add(new SqlParameter("6", employee.Password));        
                    insertCommand.Parameters.Add(new SqlParameter("6", employee.Designation));        

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


        public void AddRemark(string employeeId, Tavisca.EmployeeManagement.Model.Remark remark)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand cmdRemark = new SqlCommand("EXECUTE AddRemarkProcedure @7,@8,@9", conn);
                    cmdRemark.Parameters.Add(new SqlParameter("7", employeeId));
                    cmdRemark.Parameters.Add(new SqlParameter("8", remark.Text));
                    cmdRemark.Parameters.Add(new SqlParameter("9", remark.CreateTimeStamp.ToString()));
                    cmdRemark.ExecuteNonQuery();
                    conn.Close();

                }
                

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                
            }

        }


        public String ChangePassword(string employeeEmail, string newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand cmdRemark = new SqlCommand("EXECUTE ChangePasswordProcedure @1,@2", conn);
                    cmdRemark.Parameters.Add(new SqlParameter("1", employeeEmail));
                    cmdRemark.Parameters.Add(new SqlParameter("2", newPassword));
                    cmdRemark.ExecuteNonQuery();
                    conn.Close();
                }
                return newPassword;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }

        }


        public bool IsValid(string employeeEmail, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    SqlCommand cmdRemark = new SqlCommand("EXECUTE IsValidProcedure @1,@2", conn);
                    cmdRemark.Parameters.Add(new SqlParameter("1", employeeEmail));
                    cmdRemark.Parameters.Add(new SqlParameter("2", password));
                    SqlDataReader reader = cmdRemark.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                    conn.Close();
                }
                return false;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return false;
            }

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
                    //SqlCommand getCommand = new SqlCommand("EXECUTE GetById @0", conn);
                    SqlCommand getCommand = new SqlCommand("EXECUTE GetByIdProcedure @0", conn);
                    
                    
                    getCommand.Parameters.Add(new SqlParameter("0", employeeId));

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
                          //  employee.Password = reader[6].ToString();         
                            employee.Designation = reader[6].ToString();        
                        }
                    }

                    SqlCommand cmdGetRemark = new SqlCommand("EXECUTE GetRemarkByIdProcedure @0", conn);
                    cmdGetRemark.Parameters.Add(new SqlParameter("0", employee.Id));
                    SqlDataReader remarkReader = cmdGetRemark.ExecuteReader();
                    List<Model.Remark> remarkList = new List<Model.Remark>();
                    while (remarkReader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = remarkReader[2].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[3]);
                        remarkList.Add(remark);
                    }
                    employee.Remarks = remarkList;

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



        public Model.Employee GetByEmail(string employeeEmail)                   //remove
        {
            try
            {
                Model.Employee employee = new Model.Employee();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    //SqlCommand getCommand = new SqlCommand("EXECUTE GetById @0", conn);
                    SqlCommand getCommand = new SqlCommand("EXECUTE GetByEmailProcedure @0", conn);


                    getCommand.Parameters.Add(new SqlParameter("0", employeeEmail));

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
                           // employee.Password = reader[6].ToString();         //remove
                            employee.Designation = reader[6].ToString();        //remove
                        }
                    }


                    // SqlConnection conRemark = new SqlConnection("Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#");
                    // conRemark.Open();
                    //SqlCommand cmdGetRemark = new SqlCommand("EXECUTE GetRemarkById @0", conn);
                    SqlCommand cmdGetRemark = new SqlCommand("EXECUTE GetRemarkByIdProcedure @0", conn);
                    cmdGetRemark.Parameters.Add(new SqlParameter("0", employee.Id));
                    SqlDataReader remarkReader = cmdGetRemark.ExecuteReader();
                    List<Model.Remark> remarkList = new List<Model.Remark>();
                    while (remarkReader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = remarkReader[2].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[3]);
                        remarkList.Add(remark);
                    }
                    employee.Remarks = remarkList;

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

                using (SqlConnection conn = new SqlConnection())
                {
                    // Create the connectionString
                    // Trusted_Connection is used to denote the connection uses Windows Authentication
                    conn.ConnectionString = "Data Source=TRAINING1;Initial Catalog=PracticeDB;User ID=sa;Password=test123!@#";
                    conn.Open();
                    //SqlCommand getCommand = new SqlCommand("select * from employees", conn);
                    //using (SqlCommand getCommand = new SqlCommand("EXECUTE GetAll", conn))
                    using (SqlCommand getCommand = new SqlCommand("EXECUTE GetAllProcedure", conn))
                    {
                        // In the command, there are some parameters denoted by @, you can 
                        // change their value on a condition, in my code they're hardcoded.

                        using (SqlDataReader reader = getCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.Employee employee = new Model.Employee();
                                employee.Id = reader[0].ToString();
                                employee.Title = reader[1].ToString();
                                employee.FirstName = reader[2].ToString();
                                employee.LastName = reader[3].ToString();
                                employee.Email = reader[4].ToString();
                                employee.Phone = reader[5].ToString();
                               // employee.Password = reader[6].ToString();         //remove
                                employee.Designation = reader[6].ToString();        //remove
                                employeeList.Add(employee);
                            }
                        }

                        conn.Close();
                        //return employeeList;
                    }

                }
                return employeeList;
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

