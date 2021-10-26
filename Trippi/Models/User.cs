using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
    {
    public class User
        {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Username { get; set; }
        public List<Rating> MyRatings { get; set; }
        public List<Trip> MyTrips { get; set; }
        public List<Friends> Friends { get; set; }

        public List<TripInvites> TripInvites { get; set; }

        }
    }
