using System;

namespace MyCountry.Business.Exceptions
{
   public class DistrictValidationException : Exception
    {
        public DistrictValidationException(string message) : base(message)
        {
            
        }
    }
}
