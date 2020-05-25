namespace Emmanuel.FunBooksAndVideo.Logic.Model
{
    public class PurchaseOrderModel
    {
        public int PurchaseOrderId { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }

        public ItemLines ItemLine { get; set; }
    }
}
