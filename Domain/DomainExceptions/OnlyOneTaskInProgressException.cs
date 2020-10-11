using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OnlyOneTaskInProgressException : Exception
    {
        public OnlyOneTaskInProgressException()
        {
        }

        public OnlyOneTaskInProgressException(string message)
            : base(message)
        {
        }
    }
}
