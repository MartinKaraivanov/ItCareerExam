using AutoMapper;
using ItCareerExam.Data.Models;
using ItCareerExam.Data.Repositories;
using ItCareerExam.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ItCareerExam.Service;

public class ReviewsService : IReviewsService
{
    private readonly IRepository<Review> _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewsService(IRepository<Review> reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto)
    {
        var review = new Review { Id = Guid.NewGuid(), Feedback = reviewDto.Feedback, RestaurantId = reviewDto.Restaurant.Id, UserId = reviewDto.User.Id };

        var newReview = await _reviewRepository.AddAsync(review);

        return _mapper.Map<ReviewDto>(newReview);
    }

    public IEnumerable<ReviewDto> GetAllReviews()
    {
        return _reviewRepository.RetrieveMappedTo<ReviewDto>(x => true);
    }

    public int GetNumberOfReviews()
    {
        return _reviewRepository.Count();
    }

    public ReviewDto GetReviewById(Guid id)
    {
        var review = _reviewRepository.RetrieveMappedTo<ReviewDto>(x => x.Id == id).SingleOrDefault();

        ArgumentNullException.ThrowIfNull(review);

        return review;
    }

    public IEnumerable<ReviewDto> GetReviewsByUserId(Guid id)
    {
        return _reviewRepository.RetrieveMappedTo<ReviewDto>(x => x.User.Id == id.ToString());
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        var review = _reviewRepository.Retrieve(x => x.Id == id).SingleOrDefault();

        if (review == null)
        {
            throw new ArgumentException("Does not exist");
        }

        await _reviewRepository.RemoveAsync(review);
    }
}
