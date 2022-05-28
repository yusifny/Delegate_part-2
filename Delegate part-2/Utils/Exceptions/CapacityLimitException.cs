using System;
namespace Custom_Exceptions.Exceptions
{
    public class CapacityLimitException : Exception
    {
        public CapacityLimitException(string message) : base(message)
        {

        }
    }
}