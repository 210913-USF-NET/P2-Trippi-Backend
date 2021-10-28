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
    }

    

}