using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCareerExam.Service.Models;

public class ReviewDto
{
    public required Guid Id { get; set; }
    public required string Feedback { get; set; }
    public required RestaurantDto Restaurant { get; set; }
    public required UserDto User { get; set; }
}
