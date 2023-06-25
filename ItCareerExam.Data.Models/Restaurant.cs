using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCareerExam.Data.Models;

public class Restaurant : IEntity
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
	public required string PhotoUrl { get; set; }

	public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
