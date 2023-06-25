using ItCareerExam.Service.Models;
using ItCareerExam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ItCareerExam.WebApp.Pages.Users;

public class DeleteUserModel : PageModel
{
	private readonly IUsersService _usersService;

	[BindProperty]
	public required UserEditDto UserEditModel { get; set; }

	public DeleteUserModel(IUsersService usersService)
	{
		_usersService = usersService;
	}

	public void OnGet(string id)
	{
		UserEditModel = _usersService.GetUserEditById(id);
		UserEditModel.Password = "1";
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid)
		{
			ArgumentNullException.ThrowIfNull(UserEditModel);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (userId != UserEditModel.Id)
			{
				await _usersService.DeleteUserEditAsync(UserEditModel.Id);
			}

			return RedirectToPage("./UsersIndex");
		}

		return Page();
	}
}
