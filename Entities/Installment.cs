using System;
using System.Globalization;

namespace OnlinePaymentSystem.Entities
{
    class Installment
    {
        public DateTime DueDate { get; private set; }
        public double Amount { get; private set; }

        public Installment()
        {
        }

        public Installment(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{DueDate.ToShortDateString()} - {Amount.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
