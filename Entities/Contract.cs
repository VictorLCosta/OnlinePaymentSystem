using System;
using System.Collections.Generic;
using OnlinePaymentSystem.Entities.Exceptions;

namespace OnlinePaymentSystem.Entities
{
    class Contract
    {
        public int Number { get; private set; }
        public  DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract()
        {
        }

        public Contract(int number, DateTime date, double totalValue)
        {
            if (totalValue == 0) 
            {
                throw new DomainException("The contract value cannot be zero(0.0)");
            }
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }
    }
}
