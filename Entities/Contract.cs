using System;
using System.Collections.Generic;
using System.Text;

namespace OnlinePaymentSystem.Entities
{
    class Contract
    {
        public int Number { get; private set; }
        public  DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public List<Installment> Installments { get; set; }

        public Contract()
        {
        }

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }
    }
}
