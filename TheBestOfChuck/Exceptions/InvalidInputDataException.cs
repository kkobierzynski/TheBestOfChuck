using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestOfChuck.Exceptions
{
    public class InvalidInputDataException : Exception
    {
        public InvalidInputDataException(string message) : base(message)
        {
        }
    }
}
