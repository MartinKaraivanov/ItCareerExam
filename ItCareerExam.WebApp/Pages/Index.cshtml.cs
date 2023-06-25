using ItCareerExam.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IUsersService _usersService;
    private readonly IRestaurantsService _restaurantsService;
    private readonly IReviewsService _reviewsService;

    public int UserCount { get; set; }
    public int RestaurantsCount { get; set; }
    public int ReviewsCount { get; set; }

    public IndexModel(IUsersService usersService, IRestaurantsService restaurantsService, IReviewsService reviewsService)
    {
        _usersService = usersService;   
        _restaurantsService = restaurantsService;
        _reviewsService = reviewsService;
    }

    public void OnGet()
    {
        UserCount = _usersService.GetNumberOfUsers();
        RestaurantsCount = _restaurantsService.GetNumberOfRestaurants();
        ReviewsCount = _reviewsService.GetNumberOfReviews();
    }

}