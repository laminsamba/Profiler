﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matt.Models
{
	public static class Ingredient
	{

		// creating specific ingredient dictionaries.  will reference them by foreach loop for string values passed in for nutrients.  
		// example   reference dictionary at key == "Base Vitamin A"  etc...

		public static Dictionary<string, int> IngredientDictionary = new Dictionary<string, int>
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
			{ "Tomato: Base Vitamin A", 31  },
			{ "Tomato: Base Vitamin B", 37  },
			{ "Tomato: Base Vitamin C", 23  },
			{ "Tomato: Calories", 3  },
			{ "Tomato: Total Fat", 6  },
			{ "Tomato: Protein", 9  },
			{ "Tomato: Carbohydrates", 13  },
			{ "Tomato: Sugar", 45 },
			{ "Tomato: Sodium", 2  }
		};

		// create method to return a value when a string key is passed in. need to convert the results to an int.
		public static int BaseToInt(string input)
		{
			int value = IngredientDictionary[input];
			return value;
		}



	}

}