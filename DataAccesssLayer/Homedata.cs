using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPIDemo.Models;

namespace WebAPIDemo.DataAccesssLayer
{
    public class Homedata
    {
       public string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

        public static  List<Home> Get1()
        {
           string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        List<Home> Customers = new List<Home>();
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;
                string query = "select * from Customers";
                using (SqlConnection myCon = new SqlConnection(con))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        if (myReader.HasRows)
                        {

                            while (myReader.Read())
                            {
                                Home home = new Home();
                                home.Customerid = myReader["Customerid"].ToString();
                                home.FirstName = myReader["FirstName"].ToString();
                                home.LastName = myReader["LastName"].ToString();
                                home.Address = myReader["Address"].ToString();
                                home.City = myReader["City"].ToString();
                                home.PostalCode = myReader["PostalCode"].ToString();
                                Customers.Add(home);
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
            return Customers;
        }

        public static bool InsertProduct(newProduct1 obj)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

            // Insert the new product into the database
            using (SqlConnection myCon = new SqlConnection(con))
            {
                myCon.Open();
                string insertQuery = "INSERT INTO Customers (Customerid, FirstName, LastName) VALUES (@Customerid, @FirstName, @LastName)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, myCon);
                try
                {
                    insertCommand.Parameters.AddWithValue("@Customerid", obj.Customerid);
                    insertCommand.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    insertCommand.Parameters.AddWithValue("@LastName", obj.LastName);
                }
                catch
                {

                }
                insertCommand.ExecuteNonQuery();
                myCon.Close();
                return true;

            }
        }
        public static bool UpdateProduct(newProduct obj)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

            using (SqlConnection myCon = new SqlConnection(con))
            {
                myCon.Open();
                string insertQuery = "UPDATE Customers SET FirstName = @FirstName WHERE LastName = @LastName";
                SqlCommand insertCommand = new SqlCommand(insertQuery, myCon);
                try
                {
                    insertCommand.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    insertCommand.Parameters.AddWithValue("@LastName", obj.LastName);
                }
                catch
                {

                }
                insertCommand.ExecuteNonQuery();
                myCon.Close();
                return true;

            }
        }

    }
}