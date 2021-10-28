using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrippiBL;
using Xunit;
using Models;

namespace Tests
{
    public class BLTests
    {
        [Fact]
        public void GetNSEWShouldReturn()
        {
            System.Console.WriteLine("start of nsew test");
            IBL _bl = new BL();

            var nsew = _bl.GetNSEW(36, 36, 55);
            Console.WriteLine(nsew.Count);
            Assert.Equal(5, nsew.Count);
            
        }

        [Fact]
        public void CalculateDistanceShouldReturn()
        {
            System.Console.WriteLine("start of CalculateDistance test");
            IBL _bl = new BL();

            var dist = _bl.CalculateDistance(2, 3);
            Console.WriteLine(dist);
            Assert.Equal(300, dist);
            
        }

        [Fact]
        public async void GetAllUsersAsyncShouldReturn()
        {
            var mkusers = GetMockUsers();
            var MockyRepo = await new MockRepo().MockGetAllUsersAsync(mkusers);

            var _bl = new BL(MockyRepo.Object);

            var result = await _bl.GetAllUsersAsync();

            Assert.Equal(2, result.Count);
        }

        //  [Fact]
        // public async void GetOneUserByIdAsyncShouldReturn()
        // {
        //     var mkusers = GetMockUsers();
        //     var MockyRepo = await new MockRepo().MockGetOneUserByIdAsync(mkusers);

        //     var _bl = new BL(MockyRepo.Object);

        //     var result = await _bl.GetOneUserByIdAsync(2);

        //     Assert.Equal(2, result.Id);
        // }

        [Fact]
        public async void GetAllTripInvitesAsyncShouldReturn()
        {
            var mkusers = GetMockTripInvites();
            var MockyRepo = await new MockRepo().MockGetAllTripInvitesAsync(mkusers);

            var _bl = new BL(MockyRepo.Object);

            var result = await _bl.GetAllTripInvitesAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllTripsAsyncShouldReturn()
        {
            var mkusers = GetMockTrips();
            var MockyRepo = await new MockRepo().MockGetAllTripsAsync(mkusers);

            var _bl = new BL(MockyRepo.Object);

            var result = await _bl.GetAllTripsAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllRatingsAsyncShouldReturn()
        {
            var mkusers = GetMockRatings();
            var MockyRepo = await new MockRepo().MockGetAllRatingsAsync(mkusers);

            var _bl = new BL(MockyRepo.Object);

            var result = await _bl.GetAllRatingsAsync();

            Assert.Equal(2, result.Count);
        }


         private async Task<List<Rating>> GetMockRatings()
        {
            return new List<Rating>()
            {
                new Rating()
                {
                    Id = 1,
                    MyRating = 1
                },
                new Rating()
                {
                    Id = 2,
                    MyRating = 5
                }
            };
        }

        private async Task<List<User>> GetMockUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "test1"
                },
                new User()
                {
                    Id = 2,
                    Username = "test2"
                }
            };
        }

        private async Task<List<TripInvites>> GetMockTripInvites()
        {
            return new List<TripInvites>()
            {
                new TripInvites()
                {
                    Id = 1,
                    TripId = 3
                },
                new TripInvites()
                {
                    Id = 2,
                    TripId = 7
                }
            };

        }

         private async Task<List<Trip>> GetMockTrips()
        {
            return new List<Trip>()
            {
                new Trip()
                {
                    Id = 1,
                    RatingId = 3
                },
                new Trip()
                {
                    Id = 2,
                    RatingId = 7
                }
            };

        }
    }

    

    

}