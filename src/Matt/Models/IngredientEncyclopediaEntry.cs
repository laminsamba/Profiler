using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matt.Data;

namespace Matt.Models
{
	public class IngredientEncyclopediaEntry
	{

		public int Id { get; set; }  // Id will set the starting value for the initial ingredient displayed on the Detail View
		public string IngredientName { get; set; }


		// interesting facts about spinach
		public string DescriptionHtml { get; set; }

		//  this will convert the Ingredient to a image .jpg path
		public string IngredientDetailFileName
		{
			get
			{
				//  IngredientName followed by .jpg, no space between .jpg and the IngredientName.
				return $"{IngredientName.ToLower()}.jpg";
			}
		}


		



		


		// testing a dictionary transplant for two dictionaries.
		public static Dictionary<string, int> SpinachDictionary = new Dictionary<string, int>
		{
			{ "Spinach: Base Vitamin A", 31  },
			{ "Spinach: Base Vitamin B", 37  },
			{ "Spinach: Base Vitamin C", 23  },
			{ "Spinach: Calories", 3  },
			{ "Spinach: Total Fat", 6  },
			{ "Spinach: Protein", 9  },
			{ "Spinach: Carbohydrates", 13  },
			{ "Spinach: Sugar", 45 },
			{ "Spinach: Sodium", 2  },
		};

		public static Dictionary<string, int> TomatoDictionary = new Dictionary<string, int>
		{
			{ "Tomato: Base Vitamin A", 31  },
			{ "Tomato: Base Vitamin B", 37  },
			{ "Tomato: Base Vitamin C", 23  },
			{ "Tomato: Calories", 3  },
			{ "Tomato: Total Fat", 6  },
			{ "Tomato: Protein", 9  },
			{ "Tomato: Carbohydrates", 13  },
			{ "Tomato: Sugar", 45 },
			{ "Tomato: Sodium", 2  },
		};



		// testing a dictionary transplant for two dictionaries.
		public static Dictionary<string, int> PepperDictionary = new Dictionary<string, int>
		{
			{ "Pepper: Base Vitamin A", 31  },
			{ "Pepper: Base Vitamin B", 37  },
			{ "Pepper: Base Vitamin C", 23  },
			{ "Pepper: Calories", 3  },
			{ "Pepper: Total Fat", 6  },
			{ "Pepper: Protein", 9  },
			{ "Pepper: Carbohydrates", 13  },
			{ "Pepper: Sugar", 45 },
			{ "Pepper: Sodium", 2  },
		};


		// testing a dictionary transplant for two dictionaries.
		public static Dictionary<string, int> CarrotDictionary = new Dictionary<string, int>
		{
			{ "Carrot: Base Vitamin A", 31  },
			{ "Carrot: Base Vitamin B", 37  },
			{ "Carrot: Base Vitamin C", 23  },
			{ "Carrot: Calories", 3  },
			{ "Carrot: Total Fat", 6  },
			{ "Carrot: Protein", 9  },
			{ "Carrot: Carbohydrates", 13  },
			{ "Carrot: Sugar", 45 },
			{ "Carrot: Sodium", 2  },
		};


		// testing a dictionary transplant for two dictionaries.
		public static Dictionary<string, int> PotatoDictionary = new Dictionary<string, int>
		{
			{ "Potato: Base Vitamin A", 31  },
			{ "Potato: Base Vitamin B", 37  },
			{ "Potato: Base Vitamin C", 23  },
			{ "Potato: Calories", 3  },
			{ "Potato: Total Fat", 6  },
			{ "Potato: Protein", 9  },
			{ "Potato: Carbohydrates", 13  },
			{ "Potato: Sugar", 45 },
			{ "Potato: Sodium", 2  },
		};




		// Ingredient Constructor (instantiate a private dictionary for each ingredient on the site (4) in this case.)
		public IngredientEncyclopediaEntry()
		{
			Id = 1;

		}

	}
}