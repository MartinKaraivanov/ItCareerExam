using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ItCareerExam.WebApp.Pages.Reviews;

[Authorize]
public class YourReviewsIndexModel : PageModel
{
    private readonly IReviewsService _reviewsService;

    public IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();

    public YourReviewsIndexModel(IReviewsService reviewsService)
    {
        _reviewsService = reviewsService;
    }

    public void OnGet()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        Reviews = _reviewsService.GetReviewsByUserId(Guid.Parse(userId));
    }
}
