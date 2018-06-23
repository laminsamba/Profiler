using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matt.Models;

namespace Matt.Data
{
	public class Data
	{

		// so when we need a Meals List, we call the method InitData; below Data.Meals is the result so we just call for that, and then do some Linq processing if desired.
		public static List<Meal> Meals { get; set; }


		public static List<AddMealProfile> AddMealProfiles { get; set; }




		// this will be called , that will then call the initialization of two lists of data.
		static Data()
		{
			InitData();
		}


		private static void InitData()
		{
			// instantiate and provide the paramter values for 2 lists.
			// create the collection of Meals first so that we can refeence them when building our list of addMealProfiles.
			// use a local var meals to handle the processing, and then pass to the property Meals.
			var meals = new List<Meal>()
			{
				new Meal(Meal.MealType.HeartHealthy, "Heart Healthy"),
				new Meal(Meal.MealType.DiabetesPrevention, "Diabetes Prevention"),
				new Meal(Meal.MealType.EnergyBoost, "Boost Energy"),
				new Meal(Meal.MealType.DigestiveHealth, "Digestive Health"),
				new Meal(Meal.MealType.MuscleGrowth, "Muscle Growth"),
				new Meal(Meal.MealType.FatLoss, "Fat Loss"),
			};


			// instantiate and provide the paramter values for 2 lists, among other values from the Ingredients class, and in the proper parameter order.
			// create the collection of Meals first so that we can refeence them when building our list of addMealProfiles.
			// use a local var meals to handle the processing, and then pass to the property Meals.
			var addMealProfiles = new List<AddMealProfile>()
			{

				new AddMealProfile(1, Meal.MealType.HeartHealthy, 3, 5.8, "Matt", 3, 21, AddMealProfile.MeasurementUnit.Ounces, AddMealProfile.MeasurementUnit.Ounces,  true, true, "Olive Oil"),
				new AddMealProfile(2, Meal.MealType.FatLoss, 3, 2.8, "Matt", 63, 31, AddMealProfile.MeasurementUnit.Ounces, AddMealProfile.MeasurementUnit.Ounces, true, true, "Kale"),
				new AddMealProfile(3, Meal.MealType.MuscleGrowth, 5, 8.8, "Kate", 43, 11,  AddMealProfile.MeasurementUnit.Ounces, AddMealProfile.MeasurementUnit.Ounces, true, true, "Chicken"),
				new AddMealProfile(4, Meal.MealType.DiabetesPrevention, 3, 5.8, "Holly",  73, 16, AddMealProfile.MeasurementUnit.Ounces, AddMealProfile.MeasurementUnit.Ounces, true, true, "Fiber"),
				new AddMealProfile(5, Meal.MealType.EnergyBoost, 3, 5.7, "Adam", 83, 41, AddMealProfile.MeasurementUnit.Ounces, AddMealProfile.MeasurementUnit.Ounces, true, true, "Pasta"),
				new AddMealProfile(6, Meal.MealType.DigestiveHealth, 1, .55, "Adam", 33, 12, AddMealProfile.MeasurementUnit.Ounces,AddMealProfile.MeasurementUnit.Ounces, true, true, "Probiotics"),



			// Id = id; id of AddMealProfile i guess.
			//Meal_Id = (int)mealType;
			//PrepTime = prepTime;
			//MealCost = mealCost;
			//SpinachQuantity = spinachQuantity;
			//TomatoQuantity = tomatoQuantity;
			//MeasurementTomato = measurementTomato;
			// MeasurementSpinach = measurementSpinach;
			//SpinachCheckbox = spinachCheckbox;
			//TomatoCheckbox = tomatoCheckbox;
			//Notes = notes;

		  };


			Meals = meals;
			AddMealProfiles = addMealProfiles;


		}




	}
}