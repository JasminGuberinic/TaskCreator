using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }
    }
}
