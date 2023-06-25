namespace ItCareerExam.Data.Models;

public class Review : IEntity
{
	public required Guid Id { get; set; }
	public required string Feedback { get; set; }
	public required Guid RestaurantId { get; set; }
	public Restaurant Restaurant { get; set; } = null!;
	public required string UserId { get; set; } // todo: Guid
	public AppUser User { get; set; } = null!;
}
