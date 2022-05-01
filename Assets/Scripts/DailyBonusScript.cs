using UnityEngine;
using UnityEngine.UI;

public class DailyBonusScript : MonoBehaviour
{
	void Awake()
	{
		gameObject.GetComponent<Text>().text = $"{System.Math.Round(GetCoinsAmount(CalculateDayOfSeason()))}";
	}

	private double GetCoinsAmount(int dayNum)
	{
		if (dayNum > 30)
		{
			var temp = dayNum;
			double sum = 0;
			while (temp > 30)
			{
				sum += CalculateCoinsAmount(30);
				temp -= 30;
			}
			sum += CalculateCoinsAmount(temp);
			return sum;
		}

		else return CalculateCoinsAmount(dayNum);
	}

	private double CalculateCoinsAmount(int dayNum)
	{
		if (dayNum == 1)
			return 2;
		else if (dayNum == 2)
			return 3;
		double res = (CalculateCoinsAmount(dayNum - 2) + 0.6 * CalculateCoinsAmount(dayNum - 1));
		return res;
	}

	private int CalculateDayOfSeason()
	{
		var currentMonth = System.DateTime.Now.Month;
		var currentDayOfYear = System.DateTime.Now.DayOfYear;
		var currentYear = System.DateTime.Now.Year;

		if (currentMonth <= 2)
		{
			var countDaysInMonth = System.DateTime.DaysInMonth(System.DateTime.Now.Year, 12);
			return currentDayOfYear + countDaysInMonth;
		}

		else if (currentMonth >= 3 && currentMonth <= 5)
		{
			var tempDate = new System.DateTime(currentYear, 2, System.DateTime.DaysInMonth(currentYear, 2));
			return currentDayOfYear - tempDate.DayOfYear;
		}

		else if (currentMonth >= 6 && currentMonth <= 8)
		{
			var tempDate = new System.DateTime(currentYear, 5, System.DateTime.DaysInMonth(currentYear, 5));
			return currentDayOfYear - tempDate.DayOfYear;
		}

		else if (currentMonth >= 9 && currentMonth <= 11)
		{
			var tempDate = new System.DateTime(currentYear, 8, System.DateTime.DaysInMonth(currentYear, 8));
			return currentDayOfYear - tempDate.DayOfYear;
		}

		else if (currentMonth == 12)
		{
			var tempDate = new System.DateTime(currentYear, 11, System.DateTime.DaysInMonth(currentYear, 12));
			return currentDayOfYear - tempDate.DayOfYear;
		}

		else return 1;
	}
}
