using System;
using OnlinePaymentSystem.Entities;

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
            MyContract = myContract;
            Months = months;
        }
    }
}
