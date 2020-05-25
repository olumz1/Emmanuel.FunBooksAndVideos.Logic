using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account
{
    public interface IAccountDetails
    {
        Task<CustomerAccount> GetCustomerAccountDetails(int? customerId);

        Task UpdateCustomerAccountDetails(PurchaseOrderModel model);

        Task<MembershipType> DetermineCustomerMembership(OrderRequest model);
    }
}
