using System;
using Xunit;
using Models;

namespace BE.Tests
{
    public class ModelTests
    {
        [Fact]
        public void FriendsShouldCreate()
        {
            Friends test = new Friends();
            Assert.NotNull(test);
        }

        [Fact]
        public void RatingShouldCreate()
        {
            Rating test = new Rating();
            Assert.NotNull(test);
        }

        [Fact]
        public void TripShouldCreate()
        {
            Trip test = new Trip();
            Assert.NotNull(test);
        }

        [Fact]
        public void TripInvitesShouldCreate()
        {
            TripInvites test = new TripInvites();
            Assert.NotNull(test);
        }

        [Fact]
        public void UserShouldCreate()
        {
            User test = new User();
            Assert.NotNull(test);
        }
    }
}
