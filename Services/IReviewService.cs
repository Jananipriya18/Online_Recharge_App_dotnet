using dotnetapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(int id, Review updatedReview);
        Task<bool> DeleteReviewAsync(int id);
    }
}
