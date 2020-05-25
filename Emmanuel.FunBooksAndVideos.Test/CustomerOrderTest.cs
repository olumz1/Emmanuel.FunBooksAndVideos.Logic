using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.CustomerOrder;
using Moq;
using Xunit;

namespace Emmanuel.FunBooksAndVideos.Test
{
    public class CustomerOrderTest
    {
        [Fact]
        public void GivenCustomerId_ReturnCustomerOrder()
        {
            //Arrange
            var customerId = 4;

            var result = GetFakeCustomerOrder();

            var firstBook = result.Products.Books.FirstOrDefault();
            var firstVideo = result.Products.Videos.FirstOrDefault();

            var mockGetCustomerOrder = new Mock<IGetCustomersOrder>();

            //Act
            var sut = new BogusCustomersOrder();

            var response = sut.GetCustomersOrder(customerId).Result;

            var firstBookResponse = response.Products.Books.FirstOrDefault();
            var firstVideoResponse = response.Products.Videos.FirstOrDefault();

            //Assert
            Assert.Equal(firstBook.Author, firstBookResponse.Author);
            Assert.Equal(firstBook.Price, firstBookResponse.Price);
            Assert.Equal(firstVideo.Title, firstVideoResponse.Title);
            Assert.Equal(firstVideo.Title, firstVideoResponse.Title);
        }

        public OrderRequest GetFakeCustomerOrder()
        {
            return new OrderRequest()
            {
                Products = new ItemLines
                {
                    Books = GetFakeBookOrder(),
                    Videos = GetFakeVideoOrder()
                }
            };
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