namespace Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder
{
    public class Book : BaseProduct
    {
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int NumberOfPages { get; set; }
    }
}
