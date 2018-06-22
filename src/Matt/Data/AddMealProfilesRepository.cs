using System;
using System.Collections.Generic;
using System.Linq;
using Matt.Models;

namespace Matt.Data
{
	/// <summary>
	/// The repository for addMealProfiles.
	/// 
	/// Note: The code in this class is not to be considered a "best practice" 
	/// example of how to do data persistence, but rather as workaround for
	/// not having a database to persist data to.
	/// </summary>
	public class AddMealProfilesRepository
	{
		/// <summary>
		/// Returns a collection of addMealProfiles.
		/// </summary>
		/// <returns>A list of addMealProfiles.</returns>
		public List<AddMealProfile> GetAddMealProfiles()
		{
			return Data.AddMealProfiles
					.Join(
							Data.Meals, // The inner collection
							e => e.Meal_Id, // The outer selector
							a => a.Id,  // The inner selector
							(e, a) =>  // The result selector
							{
								e.Meal = a; // Set the AddMealProfile's Meal property
								return e; // Return the AddMealProfile
							}
							) // this bit ensures that 'LIFO' principle is followed, showing the last in the list to be displayed up top, where user eyes are most likely to be looking.
					.OrderByDescending(e => e.Id)
					.ToList();
		}

		/// <summary>
		/// Returns a single AddMealProfile for the provided ID.
		/// </summary>
		/// <param name="id">The ID for the AddMealProfile to return.</param>
		/// <returns>An AddMealProfile.</returns>
		public AddMealProfile GetAddMealProfile(int id)
		{
			AddMealProfile AddMealProfile = Data.AddMealProfiles
					.Where(e => e.Id == id)
					.SingleOrDefault();

			// Ensure that the meal property is not null.
			if (AddMealProfile.Meal == null)
			{
				AddMealProfile.Meal = Data.Meals
						.Where(a => a.Id == AddMealProfile.Meal_Id)
						.SingleOrDefault();
			}

			return AddMealProfile;
		}

		/// <summary>
		/// Adds an AddMealProfile. Looks like a mistype, live and learn how to name stuff lol.
		/// </summary>
		/// <param name="AddMealProfile">The AddMealProfile to add.</param>
		public void AddAddMealProfile(AddMealProfile AddMealProfile)
		{
			// Get the next available AddMealProfile ID.
			int nextAvailableAddMealProfileId = Data.AddMealProfiles
					.Max(e => e.Id) + 1;

			AddMealProfile.Id = nextAvailableAddMealProfileId;

			Data.AddMealProfiles.Add(AddMealProfile);
		}

		/// <summary>
		/// Updates an AddMealProfile.
		/// </summary>
		/// <param name="AddMealProfile">The AddMealProfile to update.</param>
		public void UpdateAddMealProfile(AddMealProfile AddMealProfile)
		{
			// Find the index of the AddMealProfile that we need to update.
			int AddMealProfileIndex = Data.AddMealProfiles.FindIndex(e => e.Id == AddMealProfile.Id);

			if (AddMealProfileIndex == -1)
			{
				throw new Exception(
						string.Format("Unable to find an AddMealProfile with an ID of {0}", AddMealProfile.Id));
			}

			Data.AddMealProfiles[AddMealProfileIndex] = AddMealProfile;
		}

		/// <summary>
		/// Deletes an AddMealProfile.
		/// </summary>
		/// <param name="id">The ID of the AddMealProfile to delete.</param>
		public void DeleteAddMealProfile(int id)
		{
			// Find the index of the AddMealProfile that we need to delete.
			int AddMealProfileIndex = Data.AddMealProfiles.FindIndex(e => e.Id == id);

			if (AddMealProfileIndex == -1)
			{
				throw new Exception(
						string.Format("Unable to find an AddMealProfile with an ID of {0}", id));
			}

			Data.AddMealProfiles.RemoveAt(AddMealProfileIndex);
		}
	}
}