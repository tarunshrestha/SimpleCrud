using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace MyStore.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();

        public string errorMessage = "";
        public string sucessMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.name.Length == 0 ||
                clientInfo.email.Length == 0 ||
                clientInfo.phone.Length == 0 || 
                clientInfo.address.Length == 0)
            {
                if (!clientInfo.email.Contains(".com"))
                {
                    errorMessage = "Email is not valid.";
                    return;
                }
                else if (clientInfo.phone.Length < 10)
                {
                    errorMessage = "Phone number must be more then 10 numbers";
                    return;
                }
                else
                {
                    errorMessage = "Please fill all the form.";
                    return;
                }
                
            }

            if (!clientInfo.email.Contains(".com"))
            {
                errorMessage = "Email is not valid.";
                return;
            }
            else if (clientInfo.phone.Length < 10)
            {
                errorMessage = "Phone number must be more then 10 numbers";
                return;
            }

            //Saving the new client into database
            try
            {
                String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients" +
                        "(name,email,phone,address) VALUES" +
                        "(@name,@email,@phone,@address);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);

                        command.ExecuteNonQuery();
                    } 

                }

            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }




            //empty the succed data
            clientInfo.name = "";
            clientInfo.email = "";
            clientInfo.phone = "";
            clientInfo.address = "";
            sucessMessage = "New Client has been added sucessfully.";

            Response.Redirect("/Clients");

        }

       


    }
}
