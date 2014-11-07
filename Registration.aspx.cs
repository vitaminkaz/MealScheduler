using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (IsPostBack)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			conn.Open();

			string CheckUserIsEqualTo = "SELECT COUNT(*) FROM Users WHERE UserName = '" + txtUserName.Text + "'";

			SqlCommand comm = new SqlCommand(CheckUserIsEqualTo, conn);
			int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());

			if (temp == 1)
			{
				Response.Write("User Name already registered.");
			}

			conn.Close();
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{

			
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				conn.Open();

				string InsertQuery = @"
			INSERT INTO Users (UserName, EmailAddress, Password)
OUTPUT INSERTED.id
VALUES (@username, @email, @password) ";

				SqlCommand comm = new SqlCommand(InsertQuery, conn);
				comm.Parameters.AddWithValue("@username", txtUserName.Text);
				comm.Parameters.AddWithValue("@email", txtEmail.Text);
				comm.Parameters.AddWithValue("@password", txtPassword.Text);

				int idFromCast = (int)comm.ExecuteScalar();
				Response.Redirect("Registration2.aspx?idFromCast=" + idFromCast, false);
				Response.Write("Registration successful");
				conn.Close();
			
		}
		catch (Exception ex)
		{
			Response.Write("Error: " + ex.ToString());
		}
	}
}