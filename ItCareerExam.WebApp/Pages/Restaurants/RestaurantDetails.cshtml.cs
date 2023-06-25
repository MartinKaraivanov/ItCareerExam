using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ItCareerExam.WebApp.Pages.Restaurants;

[Authorize]
public class RestaurantDetailsModel : PageModel
{
    private readonly IRestaurantsService _restaurantsService;
    private readonly IReviewsService _reviewsService;
    private readonly IUsersService _usersService;

    public required RestaurantDto Restaurant { get; set; }

    [BindProperty]
    public string Feedback { get; set; } = string.Empty;

    public RestaurantDetailsModel(IRestaurantsService restaurantsService, IReviewsService reviewsService, IUsersService usersService)
    {
        _restaurantsService = restaurantsService;
        _reviewsService = reviewsService;
        _usersService = usersService;
    }

    public void OnGet(Guid id)
    {
        Restaurant = _restaurantsService.GetRestaurantById(id);
    }

    public async Task<IActionResult> OnPostAsync(Guid id, string Feedback)
    {
        Restaurant = _restaurantsService.GetRestaurantById(id);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        var userDto = _usersService.GetUserById(Guid.Parse(userId));
        var review = new ReviewDto { Id = Guid.NewGuid(), Feedback = Feedback, Restaurant = Restaurant, User = userDto };

        await _reviewsService.CreateReviewAsync(review);

        return RedirectToPage("../Reviews/ReviewMade");
    }
}
