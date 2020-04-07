using System;
using OnlinePaymentSystem.Entities;
using OnlinePaymentSystem.Entities.Exceptions;

namespace OnlinePaymentSystem.Services
{
    class ProcessingContractService
    {
        public Contract MyContract { get; private set; }
        public int Months { get; private set; }

        public ProcessingContractService()
        {
        }

        public ProcessingContractService(Contract myContract, int months)
        {
            if (months == 0) 
            {
                throw new DomainException("The contract must be paid in installments");
            }
            MyContract = myContract;
            Months = months;
        }
    }
}
