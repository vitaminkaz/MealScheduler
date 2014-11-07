using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.ObjectModel;

public partial class Registration2 : System.Web.UI.Page
{
	int m_UserId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
		m_UserId =Convert.ToInt32( Request.QueryString["idFromCast"]);
    }
	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			ObservableCollection<FoodItem> foodItems = new ObservableCollection<FoodItem>();
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			conn.Open();

			string SelectQuery = "SELECT ID, [Nutrition Score], [Calorie Score] FROM Food";

			SqlCommand comm = new SqlCommand(SelectQuery, conn);

			//------------------------------------------
			// 1. Get Food item Information
			//------------------------------------------
			using (DbDataReader rdr = comm.ExecuteReader())
			{
				while (rdr.Read())
				{
					FoodItem fi = new FoodItem();
					
					fi.ID = rdr.GetInt32(0);
					fi.FoodScore = rdr.GetInt32(1);
					fi.Calories = rdr.GetInt32(2);
					foodItems.Add(fi);
			    }
			}

			//------------------------------------------
			// 2. Calculate food score for every item and Insert into UserFoodItemInformation table
			//------------------------------------------
			foreach (FoodItem fi in foodItems)
			{
				//figure out nausea factor ????????
				int NauseaFactor = 4;

				//figure out preference ???????
				int Preference = 4;

				//figure out recency
				bool Recency = false;

				//calculate FoodScorecore
				decimal FoodScore = fi.Calories * Convert.ToInt32(txtCalorieIntakeScore.Text) + fi.FoodScore * Convert.ToDecimal(txtNutritionScore.Text)
								+ Preference * Convert.ToInt32(txtTasteScore.Text) + NauseaFactor * Convert.ToInt32(txtNauseaScore.Text);

				//insert into UserFoodItemInformation
				string InsertQuery = @"INSERT INTO UserFoodItemsInformation (idFood, idUser, Preference,NauseaFactor,Recency, FoodScore)
										OUTPUT INSERTED.id
										VALUES (@idFood, @idUser, @Preference,@NauseaFactor,@Recency,@FoodScore) ";

				SqlCommand comm2 = new SqlCommand(InsertQuery, conn);
				comm2.Parameters.AddWithValue("@idFood", fi.ID);
				comm2.Parameters.AddWithValue("@idUser", m_UserId);
				comm2.Parameters.AddWithValue("@Preference", Preference);
				comm2.Parameters.AddWithValue("@NauseaFactor", NauseaFactor);
				comm2.Parameters.AddWithValue("@Recency", Recency);
				comm2.Parameters.AddWithValue("@FoodScore", FoodScore);

				int idFromCast = (int)comm2.ExecuteScalar();

				//if (idFromCast > 0)
				//{
				//    Response.Write(String.Format("Insert successful, FoodItemUserID = {0}", idFromCast));
				//}
				//else
				//{
				//    Response.Write("Insert failed");
				//}
				

			}
			conn.Close();
			Response.Redirect("ConstructDinner.aspx", false);

			//string SelectQuery2 = "SELECT ID, [Nutrition Score], [Calorie Score] FROM Food";
			
		}
		catch (Exception ex)
		{
			Response.Write("Error: " + ex.ToString());
		}
	}

	
}