using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Interfaces.Sipping
{
    public interface IGenerateShippingSlip
    {
       void GenerateSlippingSlip(OrderRequest model, CustomerAccount customerAccount);
    }
}
