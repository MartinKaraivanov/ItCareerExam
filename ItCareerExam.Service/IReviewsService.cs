using ItCareerExam.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCareerExam.Service;

public interface IReviewsService
{
    Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
    IEnumerable<ReviewDto> GetAllReviews();
    ReviewDto GetReviewById(Guid id);
    int GetNumberOfReviews();
    IEnumerable<ReviewDto> GetReviewsByUserId(Guid id);
    Task DeleteReviewAsync(Guid id);

}
