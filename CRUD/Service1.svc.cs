using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Delete(DeleteUser delete)
        {
            string message = "";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07IPCUO;Initial Catalog=CRUDwcf;User ID=sa;Password=erwinS12");
            connection.Open();
            SqlCommand command = new SqlCommand("delete UserTab where UserID = @UserID", connection);
            command.Parameters.AddWithValue("@UserID", delete.UID);
            int res = command.ExecuteNonQuery();
            if (res == 1)
            {
                message = "Successfully deleted!";
            }
            else
            {
                message = "Failed to delete";
            }
            return message;
        }

        public gettestdata GetInfo()
        {
            gettestdata g = new gettestdata();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07IPCUO;Initial Catalog=CRUDwcf;User ID=sa;Password=erwinS12");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from UserTab", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("mytab");
            dataAdapter.Fill(dataTable);
            g.usertab = dataTable;
            return g;
        }

        public string Insert(InsertUser user)
        {
            //return string.Format("You entered: {0}", value);

            string msg;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07IPCUO;Initial Catalog=CRUDwcf;User ID=sa;Password=erwinS12");
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into UserTab (Name, Email) values(@Name, @Email)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);

            int g = command.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Successfully Inserted!";
            }
            else
            {
                msg = "Failed to Insert!";
            }
            return msg;
        }

        public string Update(UpdateUser update)
        {
            string Message = "";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07IPCUO;Initial Catalog=CRUDwcf;User ID=sa;Password=erwinS12");
            connection.Open();
            SqlCommand command = new SqlCommand("Update UserTab set Name = @Name, Email = @Email where UserID= @UserID", connection);
            command.Parameters.AddWithValue("@UserID", update.UID);
            command.Parameters.AddWithValue("@Name", update.Name);
            command.Parameters.AddWithValue("@Email", update.Email);
            int res = command.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Successfully Updated!";
            }
            else
            {
                Message = "Failed to Update!";
            }
            return Message;
        }

    }
}
