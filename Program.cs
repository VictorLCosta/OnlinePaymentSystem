using System;
using System.Globalization;
using OnlinePaymentSystem.Entities;
using OnlinePaymentSystem.Entities.Exceptions;
using OnlinePaymentSystem.Services;

namespace OnlinePaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
            catch (FormatException f) 
            {
                Console.Clear();
                Console.WriteLine("An error ocurred:");
                Console.WriteLine(f.Message);
            }
            catch (DomainException d) 
            {
                Console.Clear();
                Console.WriteLine("An error ocurred:");
                Console.WriteLine(d.Message);
            }
        }
    }
}
