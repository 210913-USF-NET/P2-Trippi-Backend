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
        public async Task PostFreindrShouldReturnCreatedFriend()
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
            Assert.Equal(mockUser, actualResult);

            }
        [Fact]
        public async Task POIGetShuldReturnPOI()
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
        [Fact]
        public async Task PostRatingShouldReturnCreatedRating()
            {
            Rating mockRating = new Rating()
                {
                Id = 2,
                UserId = 40,
                TripId = 21,
                MyRating = 5
                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.CreateRatingAsync(mockRating)).ReturnsAsync(mockRating);


            RatingController service = new RatingController(mockBL.Object);
            var result = await service.Post(mockRating) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockRating, actualResult);

            }
        [Fact]
        public async Task GetRatingShouldReturnRating()
            {
            Rating mockRating = new Rating()
                {
                Id = 2,
                UserId = 40,
                TripId = 21,
                MyRating = 5
                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetRatingAsync(mockRating.Id)).ReturnsAsync(mockRating);


            RatingController service = new RatingController(mockBL.Object);
            var result = await service.Get(mockRating.Id) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockRating.Id );

            }
        [Fact]
        public async Task GetTripsShouldReturnListofTrips()
            {
            List<Trip> mockTrip = new List<Trip>()
                    {
                    new Trip()
                        {
                        Id = 1,
                        username = "Larry",
                        RatingId = 4,
                        StartAddress = "5595 Grand Dr, St Louis, MO 63112",
                        EndAddress = "2020 S W East Dr",
                        StartLat = 0.420453866M,
                        StartLong = -0.7143223232M,
                        EndLat = 0.4204538662M,
                        EndLong= -0.8356078468263034M,

                        },
                     new Trip()
                        {
                         Id = 4,
                        username = "Bob",
                        RatingId = 9,
                        StartAddress = "1234 Main St",
                        EndAddress = "19 Orange St W",
                        StartLat = 0.820453866M,
                        StartLong = -0.7143223232M,
                        EndLat = 0.8204538662M,
                        EndLong= -0.8356078468263034M,
                        }
                    };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllTripsAsync()).ReturnsAsync(mockTrip);


            TripController service = new TripController(mockBL.Object);
            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockTrip.Count());
            }
        [Fact]
        public async Task GetTripsbyIdShouldReturnTrip()
            {
            Trip mockTrip = new  Trip()
                        {
                        Id = 1,
                        username = "Larry",
                        RatingId = 4,
                        StartAddress = "5595 Grand Dr, St Louis, MO 63112",
                        EndAddress = "2020 S W East Dr",
                        StartLat = 0.420453866M,
                        StartLong = -0.7143223232M,
                        EndLat = 0.4204538662M,
                        EndLong= -0.8356078468263034M,

                        };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetTripAsync(1)).ReturnsAsync(mockTrip);


            TripController service = new TripController(mockBL.Object);
            var result = await service.Get(1) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(1, mockTrip.Id);
            Assert.Equal("Larry", mockTrip.username);
            }
        [Fact]
        public async Task PostTripShouldReturnCreatedTrip()
            {
            Trip mockTrip = new Trip()
                {
                Id = 1,
                username = "Larry",
                RatingId = 4,
                StartAddress = "5595 Grand Dr, St Louis, MO 63112",
                EndAddress = "2020 S W East Dr",
                StartLat = 0.420453866M,
                StartLong = -0.7143223232M,
                EndLat = 0.4204538662M,
                EndLong = -0.8356078468263034M,

                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.CreateTripAsync(mockTrip)).ReturnsAsync(mockTrip);


            TripController service = new TripController(mockBL.Object);
            var result = await service.Post(mockTrip) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockTrip, actualResult);

            }
        [Fact]
        public async Task PostTripInvitedShouldReturnCreatedTripInvite()
            {
            TripInvites mockTrip = new TripInvites()
                {
                Id = 1,
                ToUserId = 4,
                FromUserId = 8,
                TripId = 4,
                Status = 1

                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.PostInviteAsync(mockTrip)).ReturnsAsync(mockTrip);


            TripInvitesController service = new TripInvitesController(mockBL.Object);
            var result = await service.Post(mockTrip) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockTrip, actualResult);

            }
        [Fact]
        public async Task GetTripInvitesShouldReturnListofTripInvites()
            {
            List<TripInvites> mockTrip = new List<TripInvites>()
                    {
                    new TripInvites()
                        {
                        Id = 1,
                        ToUserId = 4,
                        FromUserId = 8,
                        TripId = 4,
                        Status = 1

                        },
                     new TripInvites()
                        {
                        Id = 9,
                        ToUserId = 8,
                        FromUserId = 19,
                        TripId = 7,
                        Status = 0

                        }
                    };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllTripInvitesAsync()).ReturnsAsync(mockTrip);


            TripInvitesController service = new TripInvitesController(mockBL.Object);
            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockTrip.Count());
            }
        [Fact]
        public async Task PutTripInvitedShouldReturnOkTripInvite()
            {
            TripInvites mockTrip = new TripInvites()
                {
                Id = 1,
                ToUserId = 4,
                FromUserId = 8,
                TripId = 4,
                Status = 1

                };
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.UpdateTripInviteAsync(mockTrip)).ReturnsAsync(mockTrip);


            TripInvitesController service = new TripInvitesController(mockBL.Object);
            var result = await service.Put(mockTrip) as ObjectResult;
            var actualResult = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockTrip, actualResult);

            }
        }
    }
