using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ItCareerExam.WebApp.Pages.Restaurants;

[Authorize(Roles = "Admin")]
public class CreateRestaurantModel : PageModel
{
    private readonly IRestaurantsService _restaurantsService;

    [BindProperty]
    public required RestaurantDto Restaurant { get; set; }

    public CreateRestaurantModel(IRestaurantsService restaurantsService)
    {
        _restaurantsService = restaurantsService;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            ArgumentNullException.ThrowIfNull(Restaurant);

            await _restaurantsService.CreateRestaurantAsync(Restaurant);

            return RedirectToPage("./RestaurantsIndex");
        }

        return Page();
    }
}
