using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages.Reviews;

[Authorize(Roles = "Admin")]
public class ReviewsIndexModel : PageModel
{
	private readonly IReviewsService _reviewsService;

	public IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();

	public ReviewsIndexModel(IReviewsService reviewsService)
	{
		_reviewsService = reviewsService;
	}

	public void OnGet()
	{
		Reviews = _reviewsService.GetAllReviews();
	}
}
