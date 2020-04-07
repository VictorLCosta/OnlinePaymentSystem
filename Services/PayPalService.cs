using OnlinePaymentSystem.Entities;

namespace OnlinePaymentSystem.Services
{
    class PayPalService : IOnlineService
    {
        private const double Interest = 0.01;
        private const double Fee = 0.02;

        public void GenerateQuotas(ProcessingContractService pcs)
        {
            
            double quota = pcs.MyContract.TotalValue / 3;
            for (int i = 1; i<= pcs.Months; i++) 
            {
                double total2 = 0.0;
                double total = 0.0;
                total = quota + (quota * (Interest * i));
                total2 += total + (total * Fee);

                Installment installment = new Installment(pcs.MyContract.Date.AddMonths(i), total2);

                pcs.MyContract.Installments.Add(installment);
            }
        }
    }
}
