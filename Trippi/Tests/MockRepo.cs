using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using DL;
using Models;

namespace Tests
{
    public class MockRepo : Mock<IRepo> 
    {

        public async Task<MockRepo> MockGetAllUsersAsync(Task<List<User>> results)
        {
            Setup(x => x.GetAllUsersAsync()).Returns(results);
            return this;
        }

        //  public async Task<MockRepo> MockGetOneUserByIdAsync(Task<List<User>> result)
        // {
        //     Setup(x => x.GetOneUserByIdAsync(It.IsAny<int>()))
        //     .Returns(result);
        //     return this;
        // }

          public async Task<MockRepo> MockGetAllTripInvitesAsync(Task<List<TripInvites>> results)
        {
            Setup(x => x.GetAllTripInvitesAsync()).Returns(results);
            return this;
        }

         public async Task<MockRepo> MockGetAllTripsAsync(Task<List<Trip>> results)
        {
            Setup(x => x.GetAllTripsAsync()).Returns(results);
            return this;
        }

         public async Task<MockRepo> MockGetAllRatingsAsync(Task<List<Rating>> results)
        {
            Setup(x => x.GetAllRatingsAsync()).Returns(results);
            return this;
        }
        
    }
}