using System;

namespace OnlinePaymentSystem.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message)
            : base(message) 
        { 
        }
    }
}
