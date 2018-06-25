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

		// Ingredient Constructor (instantiate a private dictionary for each ingredient on the site (4) in this case.)
		public IngredientEncyclopediaEntry()
		{
			Id = 1;

		}

	}
}