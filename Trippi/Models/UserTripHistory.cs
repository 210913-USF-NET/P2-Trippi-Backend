﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
   public class UserTripHistory
        {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }
        public User User { get; set; }
        public Trip Trip { get; set; }
        }
    }
