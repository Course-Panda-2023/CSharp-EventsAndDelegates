using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultTolerant
{
    internal class CrazyThrowExceptionFunction
    {
        public int CrazyFunction()
        {
            Random rand = new Random();
            int result = rand.Next(10);

            if (result < 5)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return result;
        }

    }
}
