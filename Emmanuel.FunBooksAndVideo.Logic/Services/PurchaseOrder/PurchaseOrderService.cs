using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.PurchaseOrder;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Sipping;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emmanuel.FunBooksAndVideo.Logic.Services.PurchaseOrder
{
    public class PurchaseOrderService : IPurchaseOrder
    {
        private readonly IGetCustomersOrder _getCustomersOrder;
        private readonly IAccountDetails _accountDetails;
        private readonly IGenerateShippingSlip _generateShippingSlip;

        public PurchaseOrderService(IGetCustomersOrder getCustomersOrder, IAccountDetails accountDetails, IGenerateShippingSlip generateShippingSlip)
        {
            _getCustomersOrder = getCustomersOrder;
            _accountDetails = accountDetails;
            _generateShippingSlip = generateShippingSlip;
        }

        public async Task ProcessPurchaseOrder(int customerId)
        {
            Random generatePurchaseOrder = new Random();
            var getCustomerDetails = await _accountDetails.GetCustomerAccountDetails(customerId);
            var retrieveCustomersOrder = await _getCustomersOrder.GetCustomersOrder(customerId);

            if (retrieveCustomersOrder == null) throw new ArgumentNullException(nameof(retrieveCustomersOrder));

                Console.WriteLine($"Activating {getCustomerDetails.FirstName}'s membership...");
            
                var memberShipType = await _accountDetails.DetermineCustomerMembership(retrieveCustomersOrder);

                Console.WriteLine($"{memberShipType} Membership activated for customer {getCustomerDetails.FirstName} {getCustomerDetails.LastName}");

            _generateShippingSlip.GenerateSlippingSlip(retrieveCustomersOrder, getCustomerDetails);
            
            var purchaseOrderModel = new PurchaseOrderModel
            {
                PurchaseOrderId = generatePurchaseOrder.Next(1000, 9999),
                CustomerId = customerId,
                Total = CalculateTotalPrice(retrieveCustomersOrder),
                ItemLine = new ItemLines
                {
                    Books = retrieveCustomersOrder.Products.Books,
                    Videos = retrieveCustomersOrder.Products.Videos,
                    MembershipType = memberShipType
                } 
            };

            Console.WriteLine("---------------------------------------Purchase Order----------------------------------------------");

            Console.WriteLine($"Purchase Order: {purchaseOrderModel.PurchaseOrderId}");
            Console.WriteLine($"Customer Id: {purchaseOrderModel.CustomerId}");
            Console.WriteLine($"Total: {purchaseOrderModel.Total}");
            foreach (var book in purchaseOrderModel.ItemLine.Books)
            {
                
                Console.WriteLine($"Book: {book.Title}");
            }

            foreach (var video in purchaseOrderModel.ItemLine.Videos)
            {

                Console.WriteLine($"Video: {video.Title}");
            }

            Console.WriteLine($"MembershipType: {purchaseOrderModel.ItemLine.MembershipType}");

            Console.WriteLine();

            await _accountDetails.UpdateCustomerAccountDetails(purchaseOrderModel);
        }

        public double CalculateTotalPrice(OrderRequest model)
        {
            var totalPriceBooks = model.Products.Books.Sum(x => x.Price);
            var totalPriceVideos = model.Products.Videos.Sum(x => x.Price);

            return totalPriceVideos + totalPriceBooks;
        }

    }
}
