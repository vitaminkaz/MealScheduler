using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

public partial class ConstructDinner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		ObservableCollection<FoodItem> foods = new ObservableCollection<FoodItem>();
		int multiplyByConst = 0;
		int ServingSizeNormalizingFactor = GetServingSizeNormalizingFactor();
		//set all scores to 5
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		
		////select all foods with their nutritional infos
		conn.Open();

		string GetDinnerMeals = "SELECT ID, Sodium, Fat, Fiber, Calories, IsMeal, FoodScore, [Serving Size] FROM Food";

		SqlCommand comm2 = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm2.ExecuteReader();

		while (reader.Read())
		{
			foods.Add(new FoodItem
			{
				ID = reader[0] != DBNull.Value ? Convert.ToInt32(reader[0]) : 0,
				Sodium = reader[1] != DBNull.Value ? Convert.ToInt32(reader[1]) : 0,
				Fat = reader[2] != DBNull.Value ? Convert.ToInt32(reader[2]) : 0,
				Fiber = reader[3] != DBNull.Value ? Convert.ToInt32(reader[3]) : 0,
				Calories = reader[4] != DBNull.Value ? Convert.ToInt32(reader[4]) : 0,
				IsMeal = Convert.ToBoolean(reader[5]),
				FoodScore = reader[6] != DBNull.Value ? Convert.ToDecimal(reader[6]) : 0,
				ServingSize = reader[7] != DBNull.Value ? Convert.ToDecimal(reader[7]) : 0
			});
		}
		conn.Close();

		foreach (FoodItem fooditem in foods)
		{

			if (fooditem.IsMeal == true)
			{
				multiplyByConst = 6;
			}
			else
			{
				multiplyByConst = 9;
			}

			//sodium
			if (fooditem.Sodium * multiplyByConst > 2000)
			{
				fooditem.FoodScore -= 2;
			}


			//fat
			if (fooditem.Fat * multiplyByConst > 65)
			{
				fooditem.FoodScore -= 2;
			}
			else
			{
				fooditem.FoodScore += 2;
			}

			//calorie
			if (fooditem.Calories * multiplyByConst > 2500)
			{
				fooditem.FoodScore -= 2;
			}
			else
			{
				fooditem.FoodScore += 2;
			}

			//fiber
			if (fooditem.Fiber > 4)
			{
				fooditem.FoodScore += 2;
			}

			fooditem.FoodScore = fooditem.FoodScore * (fooditem.ServingSize *10/ ServingSizeNormalizingFactor);
			
			conn.Open();

			string UpdateScore = "UPDATE Food SET FoodScore = " + fooditem.FoodScore + " WHERE ID= " + fooditem.ID;
			SqlCommand comm3 = new SqlCommand(UpdateScore, conn);
			int idFromCast2 = (int)comm3.ExecuteNonQuery();
			conn.Close();

		}

    }

	protected void ddlMainCourse_SelectedIndexChanged(object sender, EventArgs e)
	{
		int index = ddlMainCourse.SelectedItem.ToString().LastIndexOf("S");
		string buffer = ddlMainCourse.SelectedItem.ToString().Substring(0, index-1);
		buffer.Trim();

		AdjustFoodScoresWithCompatibilities(buffer);
		SetRecencyVariable(buffer);
		LoadSideItems();
	}

	protected void ddlSideTest_SelectedIndexChanged(object sender, EventArgs e)
	{
		int index = ddlSide.SelectedItem.ToString().LastIndexOf("S");
		string buffer = ddlSide.SelectedItem.ToString().Substring(0, index - 1);
		buffer.Trim();
		AdjustFoodScoresWithCompatibilities(buffer);
		SetRecencyVariable(buffer);
		LoadSide2Items();
	}

	private int GetServingSizeNormalizingFactor()
	{
		int score =0;
		//set all scores to 5
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

		////select all foods with their nutritional infos
		conn.Open();

		string GetDinnerMeals = @"SELECT TOP 1 [Serving Size] FROM Food
								  ORDER BY [Serving Size] DESC ";

		SqlCommand comm2 = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm2.ExecuteReader();

		while (reader.Read())
		{
			score = (reader[0] != DBNull.Value ? Convert.ToInt32(reader[0]) : 0);
		}
		
		conn.Close();
		return score;
	}

	private void SetRecencyVariable(string item)
	{
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string UpdateRecency = "UPDATE Food SET IsUsedRecently = 1 WHERE Food = '"+ item + "'";
		SqlCommand comm4 = new SqlCommand(UpdateRecency, conn);
		int idFromCast = (int)comm4.ExecuteNonQuery();
		conn.Close();
	}

	private void LoadSideItems()
	{
		List<KeyValuePair<string, int>> foods = new List<KeyValuePair<string, int>>();

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string GetDinnerMeals = @"SELECT DISTINCT TOP 7 F.ID, F.Food, F.FoodScore FROM Food F
									JOIN FoodTypes FT ON F.TypeIDs = FT.id
									WHERE FT.Type='" + FoodTypes.SideSalad + "' OR FT.Type ='" + FoodTypes.SideVegetable +  "' OR FT.Type ='" + FoodTypes.Starch +
													 "' AND F.FoodScore>=8 AND F.IsUsedRecently=0 ";


		SqlCommand comm = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm.ExecuteReader();
		while (reader.Read())
		{
			foods.Add(new KeyValuePair<string,int>(reader[1].ToString(),Convert.ToInt32(reader[2])));
		}

		foods =RandomizeIfaTie(foods);
		ddlSide.Items.Clear();
		foreach( KeyValuePair<string,int> kvp in foods)
		{
			ddlSide.Items.Add(kvp.Key + " Score:" + kvp.Value);
		}
		
		conn.Close();
	}

	private void LoadSide2Items()
	{
		List<KeyValuePair<string, int>> foods = new List<KeyValuePair<string, int>>();

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string GetDinnerMeals = @"SELECT DISTINCT TOP 7 F.ID, F.Food, F.FoodScore FROM Food F
									JOIN FoodTypes FT ON F.TypeIDs = FT.id
									WHERE FT.Type='" + FoodTypes.SideSalad + "' OR FT.Type ='" + FoodTypes.SideVegetable + "' OR FT.Type ='" + FoodTypes.Starch +
													 "' AND F.FoodScore>=8 AND F.IsUsedRecently=0 ORDER BY F.ID";


		SqlCommand comm = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm.ExecuteReader();
		while (reader.Read())
		{
			foods.Add(new KeyValuePair<string, int>(reader[1].ToString(), Convert.ToInt32(reader[2])));
		}

		foods = RandomizeIfaTie(foods);

		foreach (KeyValuePair<string, int> kvp in foods)
		{
			ddlSide2.Items.Add(kvp.Key + "  Score:" + kvp.Value);
		}

		conn.Close();
	}

	private List<KeyValuePair<string, int>> RandomizeIfaTie(List<KeyValuePair<string, int>> foods)
	{
		Random rnd = new Random();
		//sort based on score
		foods.Sort(Compare2);

		for (int i = 0; i <= Convert.ToInt32(foods.Count)-2; i++)
		{
			//look at score of the item and at the score of the one next to it, if they are the same
			if (foods[i].Value == foods[i + 1].Value)
			{
				int RandomBinary =rnd.Next(0, 2);
				//swap or not swap them (random)
				if (RandomBinary == 1)
				{
					KeyValuePair<string, int> buffer = foods[i];
					foods[i] = foods[i + 1];
					foods[i+1] = buffer;
				}
			}
		}
		return foods;
	}

	static int Compare2(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
	{
		return b.Value.CompareTo(a.Value);
	}

	private void AdjustFoodScoresWithCompatibilities(string food)
	{
		string CompatibleFoodIDs = string.Empty;
		string IncompatibleFoodIDs = string.Empty;
		char[] delimiterChars = { ',' };
		//increase score

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string GetDinnerMeals = string.Format("SELECT CompatibleFoodIDs FROM Food WHERE Food='{0}'", food);

		SqlCommand comm = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm.ExecuteReader();

		while (reader.Read())
		{
			CompatibleFoodIDs = (reader[0].ToString());
		}
		conn.Close();
		conn.Open();

		string[] ids = CompatibleFoodIDs.Split(delimiterChars);

		foreach (string id in ids)
		{
			string IncreaseScore = "UPDATE Food SET FoodScore = FoodScore + 2 WHERE ID = " + id;
			SqlCommand comm4 = new SqlCommand(IncreaseScore, conn);
			int idFromCast = (int)comm4.ExecuteNonQuery();
		}

		//Lower the score of incompatible items
		string GetIncompItems = "SELECT IncompatibleFoodItemIDs FROM Food WHERE Food='" + food + "'";

		SqlCommand comm2 = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader2 = comm.ExecuteReader();

		while (reader2.Read())
		{
			IncompatibleFoodIDs = (reader2[0].ToString());
		}
		conn.Close();
		conn.Open();

		string[] ids2 = CompatibleFoodIDs.Split(delimiterChars);

		foreach (string id in ids2)
		{
			string IncreaseScore = "UPDATE Food SET FoodScore = FoodScore - 5 WHERE ID = " + id;
			SqlCommand comm4 = new SqlCommand(IncreaseScore, conn);
			int idFromCast = (int)comm4.ExecuteNonQuery();

		}

		conn.Close();
	}

	private enum FoodTypes
	{
		DinnerMeal,
		Protein,
		Starch,
		SideSalad,
		SideVegetable,
		Dessert,
		Beverage,
		BreakfastMeal,
		Fruit,
		Snack,
		LunchMeal,
		Soup

	}

	protected void btnLoadMainCourses_Click(object sender, EventArgs e)
	{
		int adjustmentConst = 20;
		ObservableCollection<FoodItem> items = new ObservableCollection<FoodItem>();
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		
		ddlMainCourse.Items.Clear();
		conn.Open();
		string GetDinnerMealScores = @"SELECT ID, FoodScore, IsMeal FROM FOOD";


		SqlCommand comm = new SqlCommand(GetDinnerMealScores, conn);
		SqlDataReader reader = comm.ExecuteReader();

		while (reader.Read())
		{
			items.Add(new FoodItem
			{
				ID = reader[0] != DBNull.Value ? Convert.ToInt32(reader[0]) : 0,
				FoodScore = reader[1] != DBNull.Value ? Convert.ToInt32(reader[1]) : 0,
				IsMeal = Convert.ToBoolean(reader[2])
			});
		}
		conn.Close();

		foreach (FoodItem fooditem in items)
		{
			if (fooditem.IsMeal == true)
			{
				if (radRecipe.Checked == true)
				{
					fooditem.FoodScore += adjustmentConst;
				}
				else
				{
					fooditem.FoodScore -= adjustmentConst;
				}
			}

			if (fooditem.IsMeal == false)
			{
				if (radRecipe.Checked == true)
				{
					fooditem.FoodScore -= adjustmentConst;
				}
				else
				{
					fooditem.FoodScore += adjustmentConst;
				}
			}

			conn.Open();

			string UpdateScore = "UPDATE Food SET FoodScore = " + fooditem.FoodScore + ", IsUsedRecently='False' WHERE ID= " + fooditem.ID;
			SqlCommand comm3 = new SqlCommand(UpdateScore, conn);
			int idFromCast2 = (int)comm3.ExecuteNonQuery();
			conn.Close();
		}

		conn.Open();

		string GetDinnerMeals = @"SELECT TOP 10 F.Food, F.FoodScore FROM Food F
		                            JOIN FoodTypes FT ON F.TypeIDs = FT.id
		                            WHERE FT.Type='" + FoodTypes.DinnerMeal + "' OR FT.Type ='" + FoodTypes.Protein + "' AND F.IsUsedRecently=0 ORDER BY F.FoodScore DESC";


		SqlCommand comm1 = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader1 = comm1.ExecuteReader();

		List<KeyValuePair<string, int>> buffer = new List<KeyValuePair<string, int>>();

		while (reader1.Read())
		{
			buffer.Add(new KeyValuePair<string, int>(reader1[0].ToString(),Convert.ToInt32(reader1[1])));
		}

		buffer = RandomizeIfaTie(buffer);

		foreach (KeyValuePair<string, int> i in buffer)
		{
			ddlMainCourse.Items.Add((i.Key.ToString() + "     Score:" + i.Value.ToString()));
		}
		conn.Close();
	}

	protected void ddlSide2_SelectedIndexChanged(object sender, EventArgs e)
	{
		int index = ddlSide2.SelectedItem.ToString().LastIndexOf("S");
		string buffer = ddlSide2.SelectedItem.ToString().Substring(0, index - 1);
		buffer.Trim();
		AdjustFoodScoresWithCompatibilities(buffer);
		SetRecencyVariable(buffer);
		LoadDesserts();
	}

	private void LoadDesserts()
	{
		List<KeyValuePair<string, int>> foods = new List<KeyValuePair<string, int>>();

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string GetDinnerMeals = @"SELECT DISTINCT TOP 7 F.ID, F.Food, F.FoodScore FROM Food F
									JOIN FoodTypes FT ON F.TypeIDs = FT.id
									WHERE FT.Type='" + FoodTypes.Dessert + "' AND F.FoodScore>=8 AND F.IsUsedRecently=0 ORDER BY F.ID";

		SqlCommand comm = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm.ExecuteReader();
		while (reader.Read())
		{
			foods.Add(new KeyValuePair<string, int>(reader[1].ToString(), Convert.ToInt32(reader[2])));
		}

		foods = RandomizeIfaTie(foods);

		foreach (KeyValuePair<string, int> kvp in foods)
		{
			ddlDessert.Items.Add(kvp.Key + "  Score:" + kvp.Value);
		}

		conn.Close();
	}

	protected void ddlDessert_SelectedIndexChanged(object sender, EventArgs e)
	{
		int index = ddlSide2.SelectedItem.ToString().LastIndexOf("S");
		string buffer = ddlSide2.SelectedItem.ToString().Substring(0, index - 1);
		buffer.Trim();
		AdjustFoodScoresWithCompatibilities(buffer);
		SetRecencyVariable(buffer);
		LoadBeverages();
	}

	private void LoadBeverages()
	{
		List<KeyValuePair<string, int>> foods = new List<KeyValuePair<string, int>>();

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		conn.Open();

		string GetDinnerMeals = @"SELECT DISTINCT TOP 7 F.ID, F.Food, F.FoodScore FROM Food F
									JOIN FoodTypes FT ON F.TypeIDs = FT.id
									WHERE FT.Type='" + FoodTypes.Beverage + "' AND F.FoodScore>=8 AND F.IsUsedRecently=0 ORDER BY F.ID";

		SqlCommand comm = new SqlCommand(GetDinnerMeals, conn);
		SqlDataReader reader = comm.ExecuteReader();
		while (reader.Read())
		{
			foods.Add(new KeyValuePair<string, int>(reader[1].ToString(), Convert.ToInt32(reader[2])));
		}

		foods = RandomizeIfaTie(foods);

		foreach (KeyValuePair<string, int> kvp in foods)
		{
			ddlBeverage.Items.Add(kvp.Key + "  Score:" + kvp.Value);
		}

		conn.Close();
	}
}