using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ItCareerExam.WebApp.Pages.Restaurants;

[Authorize(Roles = "Admin")]
public class EditRestaurantModel : PageModel
{
	private readonly IRestaurantsService _restaurantsService;

	[BindProperty]
	public required RestaurantDto Restaurant { get; set; }

	public EditRestaurantModel(IRestaurantsService restaurantsService)
	{
		_restaurantsService = restaurantsService;
	}

	public void OnGet(Guid id)
	{
		Restaurant = _restaurantsService.GetRestaurantById(id);
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid)
		{
			ArgumentNullException.ThrowIfNull(Restaurant);

			await _restaurantsService.UpdateRestaurantAsync(Restaurant);

			return RedirectToPage("./RestaurantsIndex");
		}

		return Page();
	}
}
