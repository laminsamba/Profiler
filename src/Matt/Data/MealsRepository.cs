using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matt.Models;

namespace Matt.Data
{
	public class MealsRepository
	{

		// this will create the list of meals, that we can pass to the list of addMealProfiles
		public List<Meal> GetMeals()
		{

			return Data.Meals.OrderBy(a => a.Name).ToList();

		}

	}
}