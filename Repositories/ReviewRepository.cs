using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(int id, Review updatedReview);
        Task<bool> DeleteReviewAsync(int id);
    }

    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _dbContext.Reviews.FindAsync(id);
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateReviewAsync(int id, Review updatedReview)
        {
            var existingReview = await _dbContext.Reviews.FindAsync(id);
            if (existingReview == null)
            {
                return null;
            }

            existingReview.Subject = updatedReview.Subject;
            existingReview.Body = updatedReview.Body;

            await _dbContext.SaveChangesAsync();

            return existingReview;
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var reviewToDelete = await _dbContext.Reviews.FindAsync(id);
            if (reviewToDelete == null)
            {
                return false;
            }

            _dbContext.Reviews.Remove(reviewToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
