using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.PurchaseOrder;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Sipping;
using Emmanuel.FunBooksAndVideo.Logic.Services.Account;
using Emmanuel.FunBooksAndVideo.Logic.Services.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.PurchaseOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.Shipping;

namespace Emmanuel.FunBooksAndVideos.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = InitializeServiceProvider();
            
            var purchaseOrder = serviceProvider.GetService<IPurchaseOrder>();

            System.Console.WriteLine("please enter Customer Id (number between 1 - 9) to retrieve the customer's order");

            // Create Purchase Order
            if (int.TryParse(System.Console.ReadLine(), out int customerId))
            {
                purchaseOrder.ProcessPurchaseOrder(customerId);
                System.Console.WriteLine("Thank you for your order");
            }
            else
            {
                System.Console.WriteLine("Order number can only be numbers between 1 - 9");
            }
            
        }

        private static ServiceProvider InitializeServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IAccountDetails, BogusAccountDetails>()
                .AddTransient<IGenerateShippingSlip, GenerateShippingSlip>()
                .AddTransient<IGetCustomersOrder, BogusCustomersOrder>()
                .AddTransient<IPurchaseOrder, PurchaseOrderService>()
                .BuildServiceProvider();
        }
    }
}
