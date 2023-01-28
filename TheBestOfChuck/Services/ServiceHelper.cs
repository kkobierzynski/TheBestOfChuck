using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestOfChuck.Exceptions;

namespace TheBestOfChuck.Services
{
    public interface IServiceHelper
    {
        public bool isExceedingLength(string joke, int length);
    }

    public class ServiceHelper : IServiceHelper
    {
        public ServiceHelper() 
        {

        }

        public bool isExceedingLength(string joke, int length)
        {
            if (joke == null || length <= 0)
            {
                throw new InvalidInputDataException("Invalid input data for isExceedingLength method. Please select not nullable string or integer greater than 0.");
            }

            if (joke.Length > length)
            {
                return false;
            }
            return true;
        }
    }
}
