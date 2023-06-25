﻿using System.ComponentModel.DataAnnotations;

namespace ItCareerExam.Service.Models;

public class UserEditDto
{
    public required string Id { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

}
