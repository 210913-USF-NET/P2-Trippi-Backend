using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TrippiBL;
using Models;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BE.Tests
    {
    public class ControllerTests
        {
        [Fact]
        public async Task GetUserShouldReturnListofUserAsync()
            {
            List<User> mockUser = new List<User>()
                    {
                    new User()
                        {
                        Id = 1,
                        Username = "Larry"

                        },
                     new User()
                        {
                        Id = 2,
                        Username = "Bob"
                        }
                    };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(mockUser);

                
            UserController service = new UserController(mockBL.Object);
            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockUser.Count());
            }
        [Fact]
        public async Task GetUserByIdhouldReturnUser()
            {
           User mockUser =  new User()
                        {
                        Id = 1,
                        Username = "Larry"

                        };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetOneUserByIdAsync(1)).ReturnsAsync(mockUser);


            UserController service = new UserController(mockBL.Object);
            var result = await service.Get(1) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            }
        [Fact]
        public async Task GetUserbyUsernamehouldReturnUser()
            {
            User mockUser = new User()
                {
                Id = 1,
                Username = "Larry"

                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetOneUserByUsernameAsync("Larry")).ReturnsAsync(mockUser);


            UserController service = new UserController(mockBL.Object);
            var result = await service.Get("Larry") as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            }
        [Fact]
        public async Task PostFreindrShouldReturnCreated()
            {
            Friends mockUser = new Friends()
                {
                Id = 1,
                UserId = 4,
                FriendId =2

                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.AddFriendAsync(mockUser)).ReturnsAsync(mockUser);


            FriendController service = new FriendController(mockBL.Object);
            var result = await service.Post(mockUser) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
           
            }
        [Fact]
        public async Task POIGetShuldRetrunPOIOkcode()
            {
            List<string> mockPOI = new List<string>()
                {
                 "2345 Ridge Rd Motley Scandia Valley Township Morrison County MN US 56466",
                  "Garrison Nacogdoches County TX US 75946",
                  "1739 S County Rd 175 W Versailles Johnson Township Ripley County IN US 47042",
                  "",
                  " 4525 Oak St, Kansas City, MO 64111"

                  };
            
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.AddressToNSEWToPOI("4525 Oak St, Kansas City, MO 64111", 4, 4)).ReturnsAsync(mockPOI);


            POIcontroller service = new POIcontroller(mockBL.Object);
            var result = await service.Get("4525 Oak St, Kansas City, MO 64111", 4, 4) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockPOI, actualResult);

            }
        [Fact]
        public async Task GetRatingShouldReturnListRating()
            {
            List<Rating> mockRating = new List<Rating>()
                    {
                    new Rating()
                        {
                        Id = 1,
                        UserId = 4,
                        TripId = 2,
                        MyRating =4

                        },
                     new Rating()
                        {
                        Id = 2,
                        UserId = 40,
                        TripId = 21,
                        MyRating = 5
                        }
                    };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllRatingsAsync()).ReturnsAsync(mockRating);


            RatingController service = new RatingController(mockBL.Object);
            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockRating.Count());
            }
        }
    }
