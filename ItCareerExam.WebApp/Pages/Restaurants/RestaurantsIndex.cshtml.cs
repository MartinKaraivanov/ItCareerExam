using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages.Restaurants;

[Authorize]
public class RestaurantsIndexModel : PageModel
{
	private readonly IRestaurantsService _restaurantsService;

	public IEnumerable<RestaurantDto> Restaurants { get; set; } = new List<RestaurantDto>();

	[BindProperty]
	public string SearchName { get; set; } = string.Empty;

	public RestaurantsIndexModel(IRestaurantsService restaurantsService)
	{
		_restaurantsService = restaurantsService;
	}

	public void OnGet(string? namePart)
	{
		if (string.IsNullOrEmpty(namePart))
		{
			Restaurants = _restaurantsService.GetAllRestaurants();
		}
		else
		{
			Restaurants = _restaurantsService.GetRestaurantsByNamePart(namePart);
		}
	}

	public IActionResult OnPost()
	{
		return RedirectToPage("", new { namePart = SearchName });
	}
}
