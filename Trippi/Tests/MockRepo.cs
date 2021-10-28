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
        
    }
}