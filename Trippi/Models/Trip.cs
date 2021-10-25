﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    public class Trip
    {
        public int Id { get; set; }
        public string username { get; set; }
        public int RatingId { get; set; }
        public decimal StartLat { get; set; }
        public decimal StartLong { get; set; }
        public decimal EndLat { get; set; }
        public decimal EndLong { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public int RatingId1 { get; set; }
    }
        
}
