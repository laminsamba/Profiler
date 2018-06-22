using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matt.Data;
using Matt.Models;

namespace Matt.Controllers
{
	public class MattController : Controller
	{

		// here we call the Collections we need once up top, and then assign them below when needed.

		private AddMealProfile _addMealProfiles = null;
		private AddMealProfilesRepository _addMealProfilesRepository = null;

		// constructor for the MattController that calls the AddMealProfile() Class and assigns it 
		// to the private variable _addMealProfiles      and again for _addMealProfilesRepository
		public MattController()
		{
			_addMealProfiles = new AddMealProfile();
			_addMealProfilesRepository = new AddMealProfilesRepository();
		}

		public ActionResult Index()
		{
			// here we set the variable List<AddMealProfile> addMealProfiles to an instance of our data 
			// AddMealProfiles.  we assigned AddMealProfiles to a private List<AddMealProfile> so that it can't be changed
			// before we are ready to work with it in the ActionResult method.
			List<AddMealProfile> addMealProfiles = _addMealProfilesRepository.GetAddMealProfiles();

			// Calculate the total meal.
			double minutesSpentPreparing = addMealProfiles.Sum(e => e.PrepTime);

			// Calculate the total meal.
			double totalFoodCost = addMealProfiles.Sum(e => e.PrepTime);

			// Determine the number of meals that have addMealProfiles.
			int numberOfMeals = addMealProfiles.Count;

			// going forward, I'm going to do the model binding solution, and perform in page calculations
			// or i'll create methods and call them from the page.  This will clean up my controller area
			// and that is important when separating duties.

			ViewBag.MinutesSpentPreparing = minutesSpentPreparing;
			ViewBag.AverageTimeSpentPreparingMeals = (minutesSpentPreparing / (double)numberOfMeals);
			ViewBag.TotalFoodCost = totalFoodCost;
			ViewBag.AverageCostPerMeal = (totalFoodCost / (double)numberOfMeals);
			ViewBag.CostPerMinuteOfPreparation = (totalFoodCost / minutesSpentPreparing);
			ViewBag.MinutesPreparingPerDollarSpent = (minutesSpentPreparing / totalFoodCost);


			return View(addMealProfiles);
		}
		// we are passing in the object with all of the required paramters in our form
		public ActionResult Add()
		{
			var addMealProfile = new AddMealProfile()
			{// we can set default properties here if we want. , we will add a blank null value later, so the user has to choose one value before model state validation.
				
			};
			// this will add the list of our meals enum to the dropdownfor: so in the future, don't manually add them to a dropdown form element.  use the DropDownFor method as seen here. along with the enum.
			ViewBag.MealsSelectListItems = new SelectList(
				Data.Data.Meals, "Id", "Name");



			return View(addMealProfile);
		}

		// meal_Id represents the mealType and or Meal Goal
		[HttpPost]
		public ActionResult Add(AddMealProfile addMealProfile)
		{    
			

			// if there arent any PrepTime field validation errors, then make sure that the PrepTime
			// is greater than zero.
			if (ModelState.IsValidField("PrepTime") && addMealProfile.PrepTime <= 0)
			{
				ModelState.AddModelError("PrepTime", "The PrepTime field value must be greater than '0'.");
			}

			// name of property in quotes && name of model instance.Model_Property <= condition
			if (ModelState.IsValidField("MealCost") && addMealProfile.MealCost <= 0)
			{
				ModelState.AddModelError("MealCost", "The MealCost field value must be greater than '0'.");
			}



			if (ModelState.IsValid)
			{
				// here we set the variable List<AddMealProfile> addMealProfiles to an instance of our data 
				// AddMealProfiles.  we assigned AddMealProfiles to a private List<AddMealProfile> so that it can't be changed
				// before we are ready to work with it in the ActionResult method.
				List<AddMealProfile> addMealProfiles = _addMealProfilesRepository.GetAddMealProfiles();

				// Calculate the total meal.
				double minutesSpentPreparing = addMealProfiles.Sum(e => e.PrepTime);

				// Calculate the total meal.
				double totalFoodCost = addMealProfiles.Sum(e => e.PrepTime);

				// Determine the number of meals that have addMealProfiles.
				int numberOfMeals = addMealProfiles.Count;

				// going forward, I'm going to do the model binding solution, and perform in page calculations
				// or i'll create methods and call them from the page.  This will clean up my controller area
				// and that is important when separating duties.

				ViewBag.MinutesSpentPreparing = minutesSpentPreparing;
				ViewBag.AverageTimeSpentPreparingMeals = (minutesSpentPreparing / (double)numberOfMeals);
				ViewBag.TotalFoodCost = totalFoodCost;
				ViewBag.AverageCostPerMeal = (totalFoodCost / (double)numberOfMeals);
				ViewBag.CostPerMinuteOfPreparation = (totalFoodCost / minutesSpentPreparing);
				ViewBag.MinutesPreparingPerDollarSpent = (minutesSpentPreparing / totalFoodCost);

				_addMealProfilesRepository.AddAddMealProfile(addMealProfile);


				return View("Index", addMealProfiles);
			}
			// this will add the list of our meals enum to the dropdownfor: so in the future, don't manually add them to a dropdown form element.  use the DropDownFor method as seen here. along with the enum.
			ViewBag.MealsSelectListItems = new SelectList(
				Data.Data.Meals, "Id", "Name");

			return View(addMealProfile);  // in this case, addMealProfile object is passed in to view
		}

		// id is the path id in the address bar
		public ActionResult Results(int? id)
		{
			// accounting for possible null value and returning HttpNotFound(); error
			if (id == null)
			{
				return HttpNotFound();
			}
			// the specific meal instance returned from our makeshift database. we need to explicit cast ((int)id)
			// or use the value property of id:  (id.Value)

			// when i look in data.cs, i see that the List collection includes data for individual meal profiles.
			// so I want to return one meal profile.
			AddMealProfile specificMealProfile = _addMealProfilesRepository.GetAddMealProfile(id.Value);

			return View(specificMealProfile);
		}


		//Id = id;
		//	// will return a number referencing the type of meal from a enum list.
		//	Meal_Id = (int) mealType;
		//  PrepTime = prepTime;
		//	MealCost = mealCost;
		//	MealAuthor = mealAuthor;
		//	SpinachCheckbox = spinachCheckbox;
		//	TomatoCheckbox = tomatoCheckbox;
		//	SpinachQuantity = spinachQuantity;
		//	TomatoQuantity = tomatoQuantity;
		//	Notes = notes;

		// i want to redirect to the ActionResults method 'Results(id)  where id is the meal they were just working with; 
		// i will also need to add a few more categories maybe to the form submit Add HttpPost form.
	}
}