using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void btnLogin_Click(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			conn.Open();

			string CheckUserIsEqualTo = "SELECT COUNT(*) FROM Users WHERE UserName = '" + txtLoginUsername.Text+ "'";

			SqlCommand comm = new SqlCommand(CheckUserIsEqualTo, conn);
			int temp = 1;// Convert.ToInt32(comm.ExecuteScalar().ToString());

			conn.Close();

			if (temp == 1)
			{
				conn.Open();
				string CheckPassword = "SELECT Password FROM Users WHERE UserName = '" + txtLoginUsername.Text+ "'";
				SqlCommand PasComm = new SqlCommand(CheckPassword, conn);
				string password = PasComm.ExecuteScalar().ToString().Replace(" ", "");

				if (password == txtLoginPassword.Text)
				{
					Session["New"] = txtLoginUsername.Text;
					Response.Write("Login successfull");
					Response.Redirect("Registration2.aspx");
				}
				else
				{
					Response.Write("Invalid password.");
				}

				
			}
			else{}
			
		}
	}
}