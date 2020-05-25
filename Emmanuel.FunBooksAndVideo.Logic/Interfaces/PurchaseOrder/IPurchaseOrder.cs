using System.Threading.Tasks;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrder
    {
        Task ProcessPurchaseOrder(int customerId);

        double CalculateTotalPrice(OrderRequest model);
    }
}