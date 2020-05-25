using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Services.CustomerOrder
{
    public class BogusCustomersOrder : IGetCustomersOrder
    {
       
        public async Task<OrderRequest> GetCustomersOrder(int? customerId)
        {
            if (!customerId.HasValue) throw new ArgumentNullException("customerId Id has no value");
            var orderBogusRequests = GetFakeCustomerOrder();
            if (orderBogusRequests == null) return null;
            var orderRequest = new OrderRequest
            {
                Products = orderBogusRequests.Products
            };
            return orderRequest;
        }

        public FakeOrderRequest GetFakeCustomerOrder()
        {
            return new FakeOrderRequest { Products = new ItemLines
            {
                Books = GetFakeBookOrder(),
                Videos = GetFakeVideoOrder()
            }};
        }

        public List<Book> GetFakeBookOrder()
        {
            return new List<Book> 
            { 
                new Book
                {
                    Author = "Arthur Parker",
                    Description = "The story about the golden palace",
                    NumberOfPages = 1000,
                    Isbn = "1299-8998-9987-788788",
                    Price = 23.00,
                    ProductId = 4555,
                    ProductType = ProductType.Physical,
                    Title = "The golden palace"
                },
                new Book
                {
                    Author = "Joe Blogs",
                    Description = "The story about the silver palace",
                    NumberOfPages = 1000,
                    Isbn = "1299-8998-9987-788799",
                    Price = 20.00,
                    ProductId = 4556,
                    ProductType = ProductType.Physical,
                    Title = "The silver palace"
                },
                new Book
                {
                    Author = "Fred King",
                    Description = "The story about the bronze palace",
                    NumberOfPages = 1000,
                    Isbn = "1299-8998-9987-788700",
                    Price = 13.00,
                    ProductId = 45765,
                    ProductType = ProductType.Online,
                    Title = "The bronze palace"
                }

            };
        }

        public List<Video> GetFakeVideoOrder()
        {
            return new List<Video>
            {
                new Video
                {
                    Description = "The video about the golden palace",
                    VideoFormat = ".MP4",
                    Price = 23.00,
                    ProductId = 4555,
                    ProductType = ProductType.Online,
                    Title = "The golden palace video"
                },
                new Video
                {
                    Description = "The video about the silver palace",
                    VideoFormat = ".MP4",
                    Price = 20.00,
                    ProductId = 4556,
                    ProductType = ProductType.Physical,
                    Title = "The silver palace video"
                },
                new Video
                {
                    Description = "The video about the bronze palace",
                    VideoFormat = ".MP4",
                    Price = 13.00,
                    ProductId = 45765,
                    ProductType = ProductType.Online,
                    Title = "The bronze palace video"
                }

            };
        }
    }
}
