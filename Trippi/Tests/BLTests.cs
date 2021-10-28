using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrippiBL;
using Xunit;

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
    }

    

}