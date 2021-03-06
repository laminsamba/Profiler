﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// added namespace reference for my IngredientEnclyclopedia class 'Matt.Models'
using Matt.Models;

// make sure to add a using statement for the controller that includes this namespace (i haven't created controller yet)
namespace Matt.Data
{

	// this class has a static array of initialized Ingredient objects.  Later we can assign the values to Ingredient type objects and work with them, or just reference them directly by index and property.  _ingredientsRepository[0].Name; for example.
	public class IngredientsRepository
	{
		// this is where I can initialize my Ingredient type/class/model array of Ingredient objects  _ingredientsRepository.
		private static IngredientEncyclopediaEntry[] _ingredientsRepository = new IngredientEncyclopediaEntry[]
		{

				new IngredientEncyclopediaEntry()
				{  // initializer inside curly braces
					Id = 1,
					IngredientName = "Tomato",
					DescriptionHtml =  
																	"Donec at nisl lacinia, convallis justo eu, suscipit urna. Aenean nibh ex, pellentesque ac magna at, venenatis vehicula massa. Nunc sodales efficitur dui eget pharetra. Cras eget facilisis lectus, eget interdum justo. Vivamus quis leo nulla. Nam porta, arcu nec feugiat pretium, odio nunc pretium leo, nec placerat urna mi nec sem. Suspendisse scelerisque nibh id consequat sodales. Maecenas sodales velit tristique, maximus felis vitae, semper felis. Phasellus tincidunt, lorem ut venenatis porta, dolor est dapibus mi, eu bibendum libero eros eget magna. In vehicula, augue faucibus gravida ornare, odio lorem molestie lacus, egestas auctor massa diam eu felis. Mauris sit amet lobortis ante, eu tristique purus. Suspendisse convallis a eros vitae accumsan. Ut mollis, sapien in malesuada laoreet, nisi sapien feugiat est, ac semper leo augue at lorem." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus.",
									
														//  display bootstrap classes example  d-none d-md-block d-xl-none
					
					
				},  // comma separated for multiple array objects; last object doesn't require one.

				new IngredientEncyclopediaEntry()
				{  // initializer inside curly braces
					Id = 2,
					IngredientName = "Carrot",


					DescriptionHtml =
																	"Donec at nisl lacinia, convallis justo eu, suscipit urna. Aenean nibh ex, pellentesque ac magna at, venenatis vehicula massa. Nunc sodales efficitur dui eget pharetra. Cras eget facilisis lectus, eget interdum justo. Vivamus quis leo nulla. Nam porta, arcu nec feugiat pretium, odio nunc pretium leo, nec placerat urna mi nec sem. Suspendisse scelerisque nibh id consequat sodales. Maecenas sodales velit tristique, maximus felis vitae, semper felis. Phasellus tincidunt, lorem ut venenatis porta, dolor est dapibus mi, eu bibendum libero eros eget magna. In vehicula, augue faucibus gravida ornare, odio lorem molestie lacus, egestas auctor massa diam eu felis. Mauris sit amet lobortis ante, eu tristique purus. Suspendisse convallis a eros vitae accumsan. Ut mollis, sapien in malesuada laoreet, nisi sapien feugiat est, ac semper leo augue at lorem." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus.",


				},  // comma separated for multiple array objects; last object doesn't require one.

				new IngredientEncyclopediaEntry()
				{  // initializer inside curly braces
					Id = 3,
					IngredientName = "Potato",

					DescriptionHtml =
																	"Donec at nisl lacinia, convallis justo eu, suscipit urna. Aenean nibh ex, pellentesque ac magna at, venenatis vehicula massa. Nunc sodales efficitur dui eget pharetra. Cras eget facilisis lectus, eget interdum justo. Vivamus quis leo nulla. Nam porta, arcu nec feugiat pretium, odio nunc pretium leo, nec placerat urna mi nec sem. Suspendisse scelerisque nibh id consequat sodales. Maecenas sodales velit tristique, maximus felis vitae, semper felis. Phasellus tincidunt, lorem ut venenatis porta, dolor est dapibus mi, eu bibendum libero eros eget magna. In vehicula, augue faucibus gravida ornare, odio lorem molestie lacus, egestas auctor massa diam eu felis. Mauris sit amet lobortis ante, eu tristique purus. Suspendisse convallis a eros vitae accumsan. Ut mollis, sapien in malesuada laoreet, nisi sapien feugiat est, ac semper leo augue at lorem." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus.",

				},  // comma separated for multiple array objects; last object doesn't require one.

				new IngredientEncyclopediaEntry()
				{  // initializer inside curly braces
					Id = 4,
					IngredientName = "Pepper",
					DescriptionHtml =
																	"Donec at nisl lacinia, convallis justo eu, suscipit urna. Aenean nibh ex, pellentesque ac magna at, venenatis vehicula massa. Nunc sodales efficitur dui eget pharetra. Cras eget facilisis lectus, eget interdum justo. Vivamus quis leo nulla. Nam porta, arcu nec feugiat pretium, odio nunc pretium leo, nec placerat urna mi nec sem. Suspendisse scelerisque nibh id consequat sodales. Maecenas sodales velit tristique, maximus felis vitae, semper felis. Phasellus tincidunt, lorem ut venenatis porta, dolor est dapibus mi, eu bibendum libero eros eget magna. In vehicula, augue faucibus gravida ornare, odio lorem molestie lacus, egestas auctor massa diam eu felis. Mauris sit amet lobortis ante, eu tristique purus. Suspendisse convallis a eros vitae accumsan. Ut mollis, sapien in malesuada laoreet, nisi sapien feugiat est, ac semper leo augue at lorem." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus.",

				}, // comma separated for multiple array objects; last object doesn't require one.

					new IngredientEncyclopediaEntry()
				{  // initializer inside curly braces
					Id = 5,
					IngredientName = "Spinach",
					DescriptionHtml =
																	"Donec at nisl lacinia, convallis justo eu, suscipit urna. Aenean nibh ex, pellentesque ac magna at, venenatis vehicula massa. Nunc sodales efficitur dui eget pharetra. Cras eget facilisis lectus, eget interdum justo. Vivamus quis leo nulla. Nam porta, arcu nec feugiat pretium, odio nunc pretium leo, nec placerat urna mi nec sem. Suspendisse scelerisque nibh id consequat sodales. Maecenas sodales velit tristique, maximus felis vitae, semper felis. Phasellus tincidunt, lorem ut venenatis porta, dolor est dapibus mi, eu bibendum libero eros eget magna. In vehicula, augue faucibus gravida ornare, odio lorem molestie lacus, egestas auctor massa diam eu felis. Mauris sit amet lobortis ante, eu tristique purus. Suspendisse convallis a eros vitae accumsan. Ut mollis, sapien in malesuada laoreet, nisi sapien feugiat est, ac semper leo augue at lorem." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus." +
																	"Nulla facilisi. Donec et purus aliquam, lobortis mauris non, egestas tellus. Proin in rutrum enim, sed cursus ipsum. Donec sollicitudin odio imperdiet, porta arcu quis, venenatis lorem. Sed suscipit pharetra neque, sed dignissim lorem sodales at. Nam maximus, libero at vestibulum suscipit, diam risus tristique tortor, nec dignissim ex massa non metus. Aenean bibendum euismod fermentum. Proin nec ultricies nisi. Nunc ligula ligula, eleifend tempus porta ac, feugiat non quam. Morbi posuere arcu ac tortor malesuada ornare. In diam mauris, convallis sit amet leo ut, dictum pulvinar ligula. Nunc quis mauris posuere, egestas eros non, interdum sapien. Morbi vel risus tristique ex luctus faucibus a consequat tellus. Aenean blandit finibus luctus. Proin id convallis mi, ac bibendum lacus.",

				}, // comma separated for multiple array objects; last object doesn't require one.
		};

		public  IngredientEncyclopediaEntry[] IngredientEncyclopediaEntries { get => _ingredientsRepository; set => _ingredientsRepository = value; }


		// adding a GetIngredients() method that returns an array of Ingredients.  (List)
		public IngredientEncyclopediaEntry[] GetIngredients()
		{
			return IngredientEncyclopediaEntries;
		}

		//  create a method that returns a static array Ingredient[] of instantiated Ingredient model instances (model/type/class)
		//  public  Ingredient GetIngredient()   add an id parameter so that we can return a specific Ingredient if we know its id.
		//  our Ingredient class is being referenced in a different namespace, so we need to include a using directive for it; 
		//  since this is a Data folder, and therefore has a new namespace by default, we need to include a 'using' directive 
		//  for the 'NutrientCalculator.Models' namespace


		// this method returns an Ingredient object from an array of _Ingredients
		public IngredientEncyclopediaEntry GetIngredient(int id)
		{
			// initial value is null, 
			IngredientEncyclopediaEntry returnedIngredient = null;

			foreach (var ingredient in IngredientEncyclopediaEntries)
			{
				if (ingredient.Id == id)
				{
					returnedIngredient = ingredient;
					break;
				}
			}
			// return an single pre-initialized comic book of ComicBook type/class/model from the _comicBooks[] array.
			return returnedIngredient;
		}



	}
}