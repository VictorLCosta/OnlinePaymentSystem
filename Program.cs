using System;
using System.Globalization;
using OnlinePaymentSystem.Entities;
using OnlinePaymentSystem.Services;

namespace OnlinePaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double ct_value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //contract total value
            Console.Write("Enter the number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract MyContract = new Contract(num, date, ct_value);

            ProcessingContractService contractService = new ProcessingContractService(MyContract, months);
            IOnlineService onlineService = new PayPalService();
            onlineService.GenerateQuotas(contractService);

            Console.WriteLine("Installments");
            foreach (Installment inst in MyContract.Installments) 
            {
                Console.WriteLine(inst);
            }
        }
    }
}
