using AutoMapper;
using ItCareerExam.Data.Models;
using ItCareerExam.Data.Repositories;
using ItCareerExam.Service.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ItCareerExam.Service;

public class RestaurantsService : IRestaurantsService
{
	private readonly IRepository<Restaurant> _restaurantRepository;
	private readonly IMapper _mapper;

	public RestaurantsService(IRepository<Restaurant> restaurantRepository, IMapper mapper)
	{
		_restaurantRepository = restaurantRepository;
		_mapper = mapper;
	}

	public async Task<RestaurantDto> CreateRestaurantAsync(RestaurantDto restaurantDto)
	{
		Restaurant restaurant = new Restaurant
		{
			Id = restaurantDto.Id,
			Name = restaurantDto.Name,
			Description = restaurantDto.Description,
			PhotoUrl = restaurantDto.PhotoUrl
		};

		var newRestaurant = await _restaurantRepository.AddAsync(restaurant);

		return _mapper.Map<RestaurantDto>(newRestaurant);
	}

	public IEnumerable<RestaurantDto> GetAllRestaurants()
	{
		return _restaurantRepository.RetrieveMappedTo<RestaurantDto>(x => true);
	}

	public IEnumerable<RestaurantDto> GetRestaurantsByNamePart(string namePart)
	{
		return _restaurantRepository.RetrieveMappedTo<RestaurantDto>(x => x.Name.Contains(namePart));
	}

	public RestaurantDto GetRestaurantById(Guid id)
	{
		var r = _restaurantRepository.RetrieveMappedTo<RestaurantDto>(x => x.Id == id).SingleOrDefault();

		ArgumentNullException.ThrowIfNull(r);

		return r;
	}

	public int GetNumberOfRestaurants()
	{
		return _restaurantRepository.Count();
	}

	public async Task<RestaurantDto> UpdateRestaurantAsync(RestaurantDto restaurantDto)
	{
		var restaurant = _restaurantRepository.Retrieve(x => x.Id == restaurantDto.Id).SingleOrDefault();

		if (restaurant == null)
		{
			throw new ArgumentException("Does not exist");
		}

		restaurant.Name = restaurantDto.Name;
		restaurant.Description = restaurantDto.Description;
		restaurant.PhotoUrl = restaurantDto.PhotoUrl;

		var newRestaurant = await _restaurantRepository.EditAsync(restaurant);

		return _mapper.Map<RestaurantDto>(newRestaurant);
	}

	public async Task DeleteRestaurantAsync(Guid id)
	{
		var restaurant = _restaurantRepository.Retrieve(x => x.Id == id).SingleOrDefault();

		if (restaurant == null)
		{
			throw new ArgumentException("Does not exist");
		}

		await _restaurantRepository.RemoveAsync(restaurant);
	}
}
