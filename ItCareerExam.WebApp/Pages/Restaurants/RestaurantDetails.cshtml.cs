using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages.Restaurants;

[Authorize]
public class RestaurantDetailsModel : PageModel
{
    private readonly IRestaurantsService _restaurantsService;

    public required RestaurantDto Restaurant { get; set; }

    public RestaurantDetailsModel(IRestaurantsService restaurantsService)
    {
        _restaurantsService = restaurantsService;
    }

    public void OnGet(Guid id)
    {
        Restaurant = _restaurantsService.GetRestaurantById(id);
    }
}
