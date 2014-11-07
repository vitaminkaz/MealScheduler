using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

public partial class RateFoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		ObservableCollection<FoodItem> foods = new ObservableCollection<FoodItem>();
		int multiplyByConst = 0;

		//set all scores to 5
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string ResetScore = "UPDATE Food SET FoodScore = 5 ";
		SqlCommand comm = new SqlCommand(ResetScore, conn);
		int idFromCast = (int)comm.ExecuteNonQuery();
		conn.Close();

    }

	protected void Button1_Click(object sender, EventArgs e)
	{
		Response.Redirect("RateFoods2.aspx", false);
	}
}