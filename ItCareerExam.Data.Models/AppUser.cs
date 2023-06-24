using Microsoft.AspNetCore.Identity;

namespace ItCareerExam.Data.Models;

public class AppUser : IdentityUser, IEntity
{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}