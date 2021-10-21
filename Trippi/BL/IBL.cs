using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace TrippiBL
    {
    public interface IBL
    {
        Task<User> GetOneUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<Friends> AddFriendAsync(Friends friend);
        Task DeleteUserAsync(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance">should be in km</param>
        /// <returns></returns>
         List<List<decimal>> GetNSEW(decimal latitude, decimal longitude, int distance);

        Task<User> CreateUserAsync(User user);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip> GetTripAsync(int id);
        Task DeleteTripAsync(int id);
        Task<List<Trip>> GetAllTripsAsync();

        Task<Rating> GetRatingAsync(int id);
        Task<Rating> CreateRatingAsync(Rating rating);
        Task DeleteRatingAsync(int id);
        Task<List<Rating>> GetAllRatingsAsync();
    }
}
