using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCareerExam.Service.Models;

public class RestaurantDto
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
	public required string PhotoUrl { get; set; }
}
