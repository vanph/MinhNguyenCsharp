using System;

namespace MyCountryApplication.Exceptions
{
   public class UpdateDistrictException : Exception
    {
        public UpdateDistrictException(string message) : base(message)
        {
            
        }
    }
}
