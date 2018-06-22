using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Matt.Models
{
	public class AddMealProfile
	{







		/// <summary>
		/// The MeasurementUnit of the Meal.
		/// </summary>
		public enum MeasurementUnit
		{
			Ounces,
			Grams
		}











		public AddMealProfile()
		{


		}

		/// <summary>
		/// Constructor for easily creating addMealProfiles.
		/// </summary>
		/// <param name="id">The ID for the AddMealProfile.</param>  so we can keep track of which meal profile submission is which
		/// <param name="mealType">The meal type AddMealProfile passed to the Meal_Id from the casting of the (int)MealType enum..</param>  dropdownbox
		/// <param name="prepTime">The duration for the AddMealProfile (in minutes).</param>
		/// <param name="mealCost">The duration for the AddMealProfile (in minutes).</param>
		/// <param name="mealAuthor"></param>
		/// <param name="spinachCheckbox">The ID for the spinachCheckBox.</param>
		/// <param name="tomatoCheckbox"></param>
		/// <param name="spinachQuantity">The ID for the textbox, whose value will be assigned to spinachQuantity if checked first. on form submit</param>
		/// <param name="tomatoQuantity"></param>
		/// <param name="measurementTomato"></param>
		/// /// <param name="measurementSpinach"></param>

		/// <param name="notes">The notes for the AddMealProfile.</param>
		public AddMealProfile(int id, Meal.MealType mealType,
				double prepTime, double mealCost, string mealAuthor, bool spinachCheckbox, bool tomatoCheckbox, double spinachQuantity,
				double tomatoQuantity, MeasurementUnit measurementTomato = MeasurementUnit.Ounces, MeasurementUnit measurementSpinach = MeasurementUnit.Ounces, string notes = null)

		{
			Id = id;
			// will return a number referencing the type of meal from a enum list.
			Meal_Id = (int)mealType;
			PrepTime = prepTime;
			MealCost = mealCost;
			MealAuthor = mealAuthor;
			SpinachCheckbox = spinachCheckbox;
			TomatoCheckbox = tomatoCheckbox;
			SpinachQuantity = spinachQuantity;
			TomatoQuantity = tomatoQuantity;
			MeasurementTomato = measurementTomato;
			MeasurementSpinach = measurementSpinach;
			Notes = notes;
		}

		/// <summary>
		/// The ID of the AddMealProfile order it was placed in apparently..
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// We need using System.Component.DataAnnotation; for this
		/// The meal ID for the AddMealProfile. The ID value should map to an ID in the meals collection.
		/// </summary>
		/// 

		[Display(Name = "Meal")]
		public int Meal_Id { get; set; }
		// a number that corresponds to the type of meal.





		/// <summary>
		/// The meal for the AddMealProfile.
		/// </summary>
		public Meal Meal { get; set; }

		/// <summary>
		/// The prepTime for the AddMealProfile (in minutes).
		/// </summary>
		public double PrepTime { get; set; }


		public double MealCost { get; set; }

		public string MealAuthor { get; set; }

		public bool SpinachCheckbox { get; set; }
		public bool TomatoCheckbox { get; set; }

		public double SpinachQuantity { get; set; }
		public double TomatoQuantity { get; set; }

		// the radio buttons for ounces and grams
		public MeasurementUnit MeasurementTomato { get; set; }

		// the radio buttons for ounces and grams
		public MeasurementUnit MeasurementSpinach { get; set; }


		/// <summary>
		/// The notes for the AddMealProfile.
		/// </summary>
		
		[MaxLength(200, ErrorMessage = "200 Character Limit for this Notes Field.")]
		public string Notes { get; set; }






	}
}