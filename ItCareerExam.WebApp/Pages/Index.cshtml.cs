using ItCareerExam.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItCareerExam.WebApp.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IUsersService _usersService;

    public int UserCount { get; set; }

    public IndexModel(IUsersService usersService)
    {
        _usersService = usersService;   
    }

    public void OnGet()
    {
        UserCount = _usersService.GetNumberOfUsers();
    }

}