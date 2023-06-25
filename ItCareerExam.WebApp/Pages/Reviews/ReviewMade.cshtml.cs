using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages.Reviews;

[Authorize]
public class ReviewMadeModel : PageModel
{
    public void OnGet()
    {
    }
}
