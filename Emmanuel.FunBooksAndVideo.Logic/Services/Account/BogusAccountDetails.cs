using Bogus;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emmanuel.FunBooksAndVideo.Logic.Services.Account
{
    public class BogusAccountDetails : IAccountDetails
    {
        
        public async Task<CustomerAccount> GetCustomerAccountDetails(int? customerId)
        {
            if (!customerId.HasValue) throw new ArgumentNullException("The customer Id is invalid");
            
            var customerBogusAccounts = GetBogusCustomerAccount(10);
            var customerBogusAccount = customerBogusAccounts.FirstOrDefault(x => x.CustomerId == customerId.Value);
            if (customerBogusAccount != null)
            {
                var customerAccount = new CustomerAccount
                {
                    FirstName = customerBogusAccount.FirstName,
                    LastName = customerBogusAccount.LastName,
                    CustomerId = customerBogusAccount.CustomerId,
                    Books = customerBogusAccount.Books,
                    Videos = customerBogusAccount.Videos,
                    Email = customerBogusAccount.Email,
                    MembershipType = customerBogusAccount.MembershipType
                };

                return customerAccount;
            }

            return null;
        }

        public async Task UpdateCustomerAccountDetails(PurchaseOrderModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var updateCustomerAccountDetails = await GetCustomerAccountDetails(model.CustomerId);
            updateCustomerAccountDetails.MembershipType = model.ItemLine.MembershipType;
            foreach (var book in model.ItemLine.Books)
            {
                updateCustomerAccountDetails.Books.Add(book);
            }
            foreach (var video in model.ItemLine.Videos)
            {
                updateCustomerAccountDetails.Videos.Add(video);
            }
        }

        public async Task<MembershipType> DetermineCustomerMembership(OrderRequest model)
        {

            if (model.Products.Books.Any(x => x.ProductId.HasValue) &&
                model.Products.Videos.Any(x => x.ProductId.HasValue))
                return MembershipType.Premium;

            if (model.Products.Books.Any(x => x.ProductId.HasValue) &&
                model.Products.Videos.Any(x => !x.ProductId.HasValue))
                return MembershipType.BookClub;

            if (model.Products.Books.Any(x => !x.ProductId.HasValue) &&
                model.Products.Videos.Any(x => x.ProductId.HasValue))
                return MembershipType.VideoClub;

            return MembershipType.None;
        }

        public List<FakeCustomerAccount> GetBogusCustomerAccount(int quantity)
        {
            var customerAccount = new Faker<FakeCustomerAccount>()
                .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                .RuleFor(x => x.LastName, y => y.Name.LastName())
                .RuleFor(x => x.Email, y => y.Person.Email)
                .RuleFor(x => x.CustomerId, y=>y.IndexGlobal)
                .RuleFor(x => x.MembershipType, y => y.PickRandom<MembershipType>());

            return customerAccount.Generate(quantity);
        }
    }
}
