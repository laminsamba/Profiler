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
		private IngredientsRepository _ingredientsRepository = null;

		// constructor for the MattController that calls the AddMealProfile() Class and assigns it 
		// to the private variable _addMealProfiles      and again for _addMealProfilesRepository
		public MattController()
		{
			_addMealProfiles = new AddMealProfile();
			_addMealProfilesRepository = new AddMealProfilesRepository();
			_ingredientsRepository = new IngredientsRepository();
		}

		public ActionResult Index()
		{
			// here we set the variable List<AddMealProfile> addMealProfiles to an instance of our data 
			// AddMealProfiles.  we assigned AddMealProfiles to a private List<AddMealProfile> so that it can't be changed
			// before we are ready to work with it in the ActionResult method.
			List<AddMealProfile> addMealProfiles = _addMealProfilesRepository.GetAddMealProfiles();

			// Calculate the total meal.
			int minutesSpentPreparing = addMealProfiles.Sum(e => e.PrepTime);

			// Calculate the total meal.
			double totalFoodCost = addMealProfiles.Sum(e => e.MealCost);

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
			ValidateAddMealProfile(addMealProfile);

			if (ModelState.IsValid)
			{


				// here we set the variable List<AddMealProfile> addMealProfiles to an instance of our data 
				// AddMealProfiles.  we assigned AddMealProfiles to a private List<AddMealProfile> so that it can't be changed
				// before we are ready to work with it in the ActionResult method.
				List<AddMealProfile> addMealProfiles = _addMealProfilesRepository.GetAddMealProfiles();

				// Calculate the total meal.
				double minutesSpentPreparing = addMealProfiles.Sum(e => e.PrepTime);

				// Calculate the total meal.
				double totalFoodCost = addMealProfiles.Sum(e => e.MealCost);

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
				TempData["Message"] = "Your meal entry was successfully added!";

				// here we want to stop continuous rePOSTS so we redirect to list, with no add object call
				return RedirectToAction("Index");
			}
			// this will add the list of our meals enum to the dropdownfor: so in the future, don't manually add them to a dropdown form element.  use the DropDownFor method as seen here. along with the enum.
			SetupMealsSelectListItems();

			return View(addMealProfile);  // in this case, addMealProfile object is passed in to view
		}




		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			// ToDo: get the request entry from the repository so that we can work with it and update it if need be.
			// id is a nullable int, so we need to cast it to an int in order to pass it to the getEntry method.
			AddMealProfile addMealProfile = _addMealProfilesRepository.GetAddMealProfile((int)id);


			// if the entry is not found, return status of 'file not found'.
			if (addMealProfile == null)
			{
				return HttpNotFound();

			}

			SetupMealsSelectListItems();
		
			// populate the activities select list items ViewBag property.


			// pass the entry into the view.  
			// we also need to set up a post action method for edit, just like we did for Add()
			return View(addMealProfile);

		}


		// this method will accept an entry and return a call to View Entry.
		// basically, addMealProfile is the grouping of properties from several classes that
		// represent one type of entry -- a meal, having several characteristics.
		[HttpPost]
		public ActionResult Edit(AddMealProfile addMealProfile)
		{
			ValidateAddMealProfile(addMealProfile);
			  
			if (ModelState.IsValid)
			{
				_addMealProfilesRepository.UpdateAddMealProfile(addMealProfile);
				TempData["Message"] = "Your meal entry was successfully updated.";

				return RedirectToAction("Index");
			}

			SetupMealsSelectListItems();
			
			return View(addMealProfile);
		}


		public ActionResult Delete(int? id)
		{
			AddMealProfile addMealProfile = _addMealProfilesRepository.GetAddMealProfile((int)id);

			if (id == null)
			{
				return HttpNotFound();
			}
			return View(addMealProfile);
		}



		[HttpPost]
		public ActionResult Delete(int id)
		{
			_addMealProfilesRepository.DeleteAddMealProfile(id);
			TempData["Message"] = "Your meal entry was successfully removed.";

			return RedirectToAction("Index");
		}









		// id is the path id in the address bar
		public ActionResult Results()
		{
		
			// the specific meal instance returned from our makeshift database. we need to explicit cast ((int)id)
			// or use the value property of id:  (id.Value)

			// when i look in data.cs, i see that the List collection includes data for individual meal profiles.
			// so I want to return one meal profile.
			List<AddMealProfile> addMealProfiles = _addMealProfilesRepository.GetAddMealProfiles();

			return View(addMealProfiles);
		}



		// add index action method; needs to be public and return and ActionResult object
		public ActionResult ProfileGallery()
		{

			// passing a _ingredientRepository array to the ingredient variable; this will make the array available 
			// via the View's Model property.
			var ingredients = _ingredientsRepository.GetIngredients();
			return View(ingredients);


		}


		// id is returned from the address bar path at present, but after i set up clickable linked images
		// then the ingredient id will be set up that way.
		public ActionResult Detail(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			// i initialized in the ingredient constructor an Id = 1;
			// i used .Value to cast the int? to int.  could have casted explicitly also.
			var ingredient = _ingredientsRepository.GetIngredient(id.Value);


			ViewBag.DictionaryType = IngredientEncyclopediaEntry.TomatoDictionary;





			return View(ingredient);

		}



		private void ValidateAddMealProfile(AddMealProfile addMealProfile)
		{
			if (ModelState.IsValidField("PrepTime") && addMealProfile.PrepTime <= 0)
			{
				ModelState.AddModelError("PrepTime", "The Prep Time field value must be greater than '0'.");
			}

			if (ModelState.IsValidField("MealCost") && addMealProfile.MealCost <= 0)
			{
				ModelState.AddModelError("MealCost", "The Meal Cost field value must be greater than '0'.");
			}

			if (ModelState.IsValidField("MealAuthor") && addMealProfile.MealAuthor == "" || addMealProfile.MealAuthor == null)
			{
				addMealProfile.MealAuthor = "Dr. Who";
			}

			// if the checkbox is not checked, then return null for respective quantities.
			if (ModelState.IsValidField("TomatoQuantity") && addMealProfile.TomatoCheckbox == false)
			{
				addMealProfile.TomatoQuantity = null;
			}

			if (ModelState.IsValidField("SpinachQuantity") && addMealProfile.SpinachCheckbox == false)
			{
				addMealProfile.SpinachQuantity = null;
			}
		}


		


		private void SetupMealsSelectListItems()
		{
			ViewBag.MealsSelectListItems = new SelectList(
							Data.Data.Meals, "Id", "Name");
		}




	}
}