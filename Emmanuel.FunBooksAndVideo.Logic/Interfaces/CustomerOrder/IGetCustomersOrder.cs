using System.Threading.Tasks;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder
{
    public interface IGetCustomersOrder
    {
        Task<OrderRequest> GetCustomersOrder(int? customerId);
    }
}
