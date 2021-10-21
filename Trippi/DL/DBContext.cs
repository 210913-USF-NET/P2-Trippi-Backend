using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBContext : DbContext
    {
        public DBContext() : base() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTripHistory> UserTripHistories { get; set; }
    }
}
