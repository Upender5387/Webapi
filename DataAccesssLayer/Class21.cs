using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPIDemo.Models;

namespace WebAPIDemo.DataAccesssLayer
{
    public class Class21
    {
        public string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        public static List<Classdemo> Get2()
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
            List<Classdemo> person = new List<Classdemo>();
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;
                string query = "select * from Classdemo";
                using (SqlConnection myCon = new SqlConnection(con1))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        if (myReader.HasRows)
                        {

                            while (myReader.Read())
                            {
                                Classdemo demo = new Classdemo();
                                demo.Customerid = Convert.ToInt32(myReader["Customersid"]);
                                demo.FirstName = myReader["FirstName"].ToString();
                                demo.LastName = myReader["LastName"].ToString();
                                demo.Address = myReader["Address"].ToString();
                                demo.City = myReader["City"].ToString();
                                demo.PostalCode = myReader["PostalCode"].ToString();
                                demo.Username = myReader["Username"].ToString();
                                demo.Password = myReader["Password"].ToString();
                                person.Add(demo);
                            }
                            objresutl.Load(myReader);
                            myReader.Close();
                            myCon.Close();

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return person;
        }
        public static List<Classdemo> Login(string username, string password)
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
            List<Classdemo> person = new List<Classdemo>();
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;
                string query = "select * from Classdemo where Username='" + username + "' and Password='" + password + "' ";
                using (SqlConnection myCon = new SqlConnection(con1))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        if (myReader.HasRows)
                        {

                            while (myReader.Read())
                            {
                                Classdemo demo = new Classdemo();
                                demo.Customerid = Convert.ToInt32(myReader["Customersid"]);
                                demo.FirstName = myReader["FirstName"].ToString();
                                demo.LastName = myReader["LastName"].ToString();
                                demo.Address = myReader["Address"].ToString();
                                demo.City = myReader["City"].ToString();
                                demo.PostalCode = myReader["PostalCode"].ToString();
                                demo.Username = myReader["Username"].ToString();
                                demo.Password = myReader["Password"].ToString();



                                person.Add(demo);
                            }
                            objresutl.Load(myReader);
                            myReader.Close();
                            myCon.Close();

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return person;
        }

        public static bool InsertProduct1(Product1 obj)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

            // Insert the new product into the database
            using (SqlConnection myCon = new SqlConnection(con))
            {
                myCon.Open();
                string insertQuery = "INSERT INTO Classdemo (Customersid,FirstName,LastName,Address,City,PostalCode,Username,Password) VALUES (@Customerid,@FirstName, @LastName,@Address,@City,@PostalCode,@Username,@Password)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, myCon);
                try
                {
                    insertCommand.Parameters.AddWithValue("@Customerid", obj.Customersid);
                    insertCommand.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    insertCommand.Parameters.AddWithValue("@LastName", obj.LastName);
                    insertCommand.Parameters.AddWithValue("@Address", obj.Address);
                    insertCommand.Parameters.AddWithValue("@City", obj.City);
                    insertCommand.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
                    insertCommand.Parameters.AddWithValue("@Username", obj.Username);
                    insertCommand.Parameters.AddWithValue("@Password", obj.Password);
                }
                catch
                {

                }
                insertCommand.ExecuteNonQuery();
                myCon.Close();
                return true;
            }
        }
        public static bool UpdateProduct1(Product obj1)
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

            using (SqlConnection myCon1 = new SqlConnection(con1))
            {
                myCon1.Open();
                string updateQuery = "UPDATE Classdemo SET FirstName = @FirstName, LastName=@LastName WHERE Customersid = @Customerid";
                SqlCommand UpdateQuery = new SqlCommand(updateQuery, myCon1);
                try
                {
                    UpdateQuery.Parameters.AddWithValue("@Customerid", obj1.Customerid);
                    UpdateQuery.Parameters.AddWithValue("@FirstName", obj1.FirstName);
                    UpdateQuery.Parameters.AddWithValue("@LastName", obj1.LastName);
                   

                }
                catch
                {

                }
                UpdateQuery.ExecuteNonQuery();
                myCon1.Close();
                return true;


            }
        }
        public static bool DeleteProduct1(Product12 obj1)
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

            using (SqlConnection myCon12 = new SqlConnection(con1))
            {
                myCon12.Open();
                string updateQuery = "DELETE from Classdemo WHERE Customersid = @Customerid";
                SqlCommand UpdateQuery = new SqlCommand(updateQuery, myCon12);
                try
                {
                    UpdateQuery.Parameters.AddWithValue("@Customerid", obj1.Customerid);
                    
                }
                catch
                {

                }
                UpdateQuery.ExecuteNonQuery();
                myCon12.Close();
                return true;


            }
        }
    }

}
