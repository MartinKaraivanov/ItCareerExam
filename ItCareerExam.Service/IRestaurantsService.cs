using ItCareerExam.Service.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ItCareerExam.Service;

public interface IRestaurantsService
{
	Task<RestaurantDto> CreateRestaurantAsync(RestaurantDto restaurantDto);
	IEnumerable<RestaurantDto> GetAllRestaurants();
	IEnumerable<RestaurantDto> GetRestaurantsByNamePart(string namePart);
	RestaurantDto GetRestaurantById(Guid id);
	int GetNumberOfRestaurants();
	Task<RestaurantDto> UpdateRestaurantAsync(RestaurantDto restaurantDto);
	Task DeleteRestaurantAsync(Guid id);
}
