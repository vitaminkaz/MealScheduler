using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FoodItem
/// </summary>
public class FoodItem
{
	public FoodItem()
	{
		
	
	}

	private int m_ID;

	/// <summary>
	/// Get or set the value of ID
	/// </summary>
	public int ID
	{
		get { return m_ID; }

		set
		{
			if (m_ID != value)
			{
				m_ID = value;
			}
		}
	}

	private decimal m_FoodScore;

	/// <summary>
	/// Get or set the value of NutritionScore
	/// </summary>
	public decimal FoodScore
	{
		get { return m_FoodScore; }

		set
		{
			if (m_FoodScore != value)
			{
				m_FoodScore = value;
			}
		}
	}

	private int m_Sodium;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public int Sodium
	{
		get { return m_Sodium; }

		set
		{
			if (m_Sodium != value)
			{
				m_Sodium = value;
			}
		}
	}

	private int m_Fat;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public int Fat
	{
		get { return m_Fat; }

		set
		{
			if (m_Fat != value)
			{
				m_Fat = value;
			}
		}
	}

	private int m_Fiber;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public int Fiber
	{
		get { return m_Fiber; }

		set
		{
			if (m_Fiber != value)
			{
				m_Fiber = value;
			}
		}
	}

	private int m_Calories;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public int Calories
	{
		get { return m_Calories; }

		set
		{
			if (m_Calories != value)
			{
				m_Calories = value;
			}
		}
	}

	private bool m_IsMeal;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public bool IsMeal
	{
		get { return m_IsMeal; }

		set
		{
			if (m_IsMeal != value)
			{
				m_IsMeal = value;
			}
		}
	}

	private decimal m_ServingSize;

	/// <summary>
	/// Get or set the value of CalorieScore
	/// </summary>
	public decimal ServingSize
	{
		get { return m_ServingSize; }

		set
		{
			if (m_ServingSize != value)
			{
				m_ServingSize = value;
			}
		}
	}

	
}