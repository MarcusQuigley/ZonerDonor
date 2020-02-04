using System;
using System.Collections.Generic;
using System.Text;

namespace ZonerDonor.Utils.Extensions
{
 public static class IntExtensions
    {
        public static int RandomNumberLessThan(this int value)
        {
            return new Random().Next(value - 1);
        }
    }
}
