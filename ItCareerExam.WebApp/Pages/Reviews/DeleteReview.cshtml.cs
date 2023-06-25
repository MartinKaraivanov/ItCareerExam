using ItCareerExam.Service;
using ItCareerExam.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages.Reviews;

[Authorize]
public class DeleteReviewModel : PageModel
{
    private readonly IReviewsService _reviewsService;

    public required ReviewDto Review { get; set; }

    public required string ReturnPage { get; set; }

    public DeleteReviewModel(IReviewsService reviewsService)
    {
        _reviewsService = reviewsService;
    }

    public void OnGet(Guid id, string returnPage)
    {
        Review = _reviewsService.GetReviewById(id);
        ReturnPage = returnPage;
    }

    public async Task<IActionResult> OnPostAsync(Guid id, string returnPage)
    {
        if (ModelState.IsValid)
        {
            await _reviewsService.DeleteReviewAsync(id);

            return RedirectToPage($"./{returnPage}");
        }

        return Page();
    }
}
