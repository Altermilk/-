using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KettleOOP
{
    internal class KettleErrors
    {
        internal class NotEnoughWaterException : Exception
        {
            public NotEnoughWaterException() : base("Not enough water to boil") { }
        }
    }
}
