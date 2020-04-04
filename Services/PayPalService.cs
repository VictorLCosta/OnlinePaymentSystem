using OnlinePaymentSystem.Entities;

namespace OnlinePaymentSystem.Services
{
    class PayPalService : IOnlineService
    {
        private const double Interest = 0.01;
        private const double Fee = 0.02;

        public void GenerateQuotas(ProcessingContractService pcs)
        {
            double total = 0.0;
            double total2 = 0.0;
            double quotas = pcs.MyContract.TotalValue / 3;
            for (int i = 1; i<= pcs.Months; i++) 
            {
                total += quotas * (Interest * i);
                total2 += total * Fee;
                pcs.MyContract.Installments.Add(new Installment(pcs.MyContract.Date.AddMonths(i), pcs.MyContract.TotalValue));
            }
        }
    }
}
