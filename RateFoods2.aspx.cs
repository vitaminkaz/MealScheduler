using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

public partial class RateFoods2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		List<KeyValuePair<int, int>> foodKinds = new List<KeyValuePair<int, int>>();

		List<KeyValuePair<int, string>> foods = new List<KeyValuePair<int, string>>();
		char[] delimiterChars = { ',' };

		//set all scores to 5
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string SelectFoodKindScores = @"Select id, Score FROM FoodKinds";

		SqlCommand comm = new SqlCommand(SelectFoodKindScores, conn);
		SqlDataReader reader = comm.ExecuteReader();
		while (reader.Read())
		{
			foodKinds.Add(new KeyValuePair<int, int>(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1])));
		}

		conn.Close();

		conn.Open();

		string SelectFoodsScores = @"Select id, FoodKindIDs FROM Food";

		SqlCommand comm2 = new SqlCommand(SelectFoodsScores, conn);
		SqlDataReader reader2 = comm2.ExecuteReader();
		while (reader2.Read())
		{
			foods.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader2[0]), Convert.ToString(reader2[1])));
		}
		conn.Close();

		conn.Open();

		foodKinds.Sort(Compare2);

		foreach (KeyValuePair<int, string> kvpf in foods)
		{
			kvpf.Value.Trim();
			string[] FoodKindIds =kvpf.Value.Split(delimiterChars);

			if (FoodKindIds[0].Length > 0)
			{

				List<KeyValuePair<int, int>> FoodKind_Score_ForParticularFood = new List<KeyValuePair<int, int>>();


				//only get the food kinds relevant for this dish
				foreach (string foodKindID in FoodKindIds)
				{
					if (foodKinds.FirstOrDefault(fk => fk.Key == Convert.ToInt32(foodKindID)).Key >0)
					{
						FoodKind_Score_ForParticularFood.Add(foodKinds.FirstOrDefault(fk => fk.Key == Convert.ToInt32(foodKindID)));
					}
					
				}

				//get the minimum score among all food kinds associated with that dish
				FoodKind_Score_ForParticularFood.Sort(Compare2);

				//update that dishe's score to the minimum food kind score found
				string AdjustScore = "UPDATE Food SET FoodScore =" + FoodKind_Score_ForParticularFood.Last().Value + "WHERE ID=" + kvpf.Key;
				SqlCommand comm4 = new SqlCommand(AdjustScore, conn);
				int idFromCast = (int)comm4.ExecuteNonQuery();
			}
			else
			{
				string AdjustScore = "UPDATE Food SET FoodScore = 5 WHERE ID=" + kvpf.Key;
				SqlCommand comm4 = new SqlCommand(AdjustScore, conn);
				int idFromCast = (int)comm4.ExecuteNonQuery();
			}
		}
		
    }

	static int Compare2(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
	{
		return b.Value.CompareTo(a.Value);
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		Response.Redirect("ConstructDinner.aspx", false);
	}
}