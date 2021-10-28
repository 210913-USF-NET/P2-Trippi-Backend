using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Models;
using DL;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BE.Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<DBContext> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<DBContext>().UseSqlite("Filename=Test.db").Options;

            Seed();
        }

         [Fact]
        public async void GetAllUsersAsyncShouldGetAllUsersAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var usos = await repo.GetAllUsersAsync();
                
                //Assert
                Assert.NotNull(usos);
                Assert.Equal(2, usos.Count);
            }
        }

         [Fact]
        public async void GetOneUserByIdAsyncShouldGetOneUserByIdAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var uso = await repo.GetOneUserByIdAsync(1);
                
                //Assert
                Assert.NotNull(uso);
                
            }
        }

         [Fact]
        public async void GetOneUserByUsernameAsyncShouldGetOneUserByUsernameAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var uso = await repo.GetOneUserByUsernameAsync("test");
                
                //Assert
                Assert.NotNull(uso);
                
            }
        }

         [Fact]
        public async void GetAllTripInvitesAsyncShouldGetAllTripInvitesAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var ios = await repo.GetAllTripInvitesAsync();
                
                //Assert
                Assert.NotNull(ios);
                Assert.Equal(2, ios.Count);
            }
        }

         [Fact]
        public async void GetTripAsyncShouldGetTripAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var tos = await repo.GetTripAsync(1);
                
                //Assert
                Assert.NotNull(tos);
                
            }
        }

         [Fact]
        public async void GetAllTripsAsyncShouldGetAllTripsAsync()
        {
            using(var context = new DBContext(options))
            {
                //Arrange
                IRepo repo = new Repo(context);

                //Act
                var tos = await repo.GetAllTripsAsync();
                
                //Assert
                Assert.NotNull(tos);
                Assert.Equal(2, tos.Count);
            }
        }
        
        private void Seed()
        {
            using(var context = new DBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.AddRange(
                    new User(){
                        Id = 1,
                        Username = "test"


                    },
                    new User(){
                        Id = 2,
                        Username = "test2"


                    }
                );

                context.TripInvites.AddRange(
                    new TripInvites(){
                        Id = 1,
                        ToUserId = 2,
                        FromUserId = 1,
                        TripId = 1,
                        Status = 0
                    },
                    new TripInvites(){
                        Id = 2,
                        ToUserId = 2,
                        FromUserId = 1,
                        TripId = 2,
                        Status = 0 
                    }
                );

                context.Trips.AddRange(
                    new Trip(){
                        Id = 1
                    },
                    new Trip(){
                        Id = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}