using Emmanuel.FunBooksAndVideo.Logic.Enum;

namespace Emmanuel.FunBooksAndVideo.Logic.Model
{
    public class BaseProduct
    {
        public int? ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ProductType ProductType { get; set; }
    }
}
