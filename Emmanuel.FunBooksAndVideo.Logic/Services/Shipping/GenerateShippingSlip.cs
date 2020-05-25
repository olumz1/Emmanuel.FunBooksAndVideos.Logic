using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Sipping;
using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using System;
using System.Linq;

namespace Emmanuel.FunBooksAndVideo.Logic.Services.Shipping
{
    public class GenerateShippingSlip : IGenerateShippingSlip
    {
        public void GenerateSlippingSlip(OrderRequest model, CustomerAccount customerAccount)
        {
            if (model == null || customerAccount == null) throw new ArgumentNullException(nameof(model), "The model to generate a shipping slip can not be null");

            Console.WriteLine("---------------------------------------Shipping Label----------------------------------------------");

            Console.WriteLine($"Shipping slip for {customerAccount.FirstName} {customerAccount.LastName}");

            foreach (var book in model.Products.Books.Where(book => book.ProductType == ProductType.Physical))
            {
                Console.WriteLine($"Book Title = {book.Title}");
            }

            foreach (var video in model.Products.Videos.Where(video => video.ProductType == ProductType.Physical))
            {
                Console.WriteLine($"Video Title = {video.Title}");
            }
        }
    }
}
