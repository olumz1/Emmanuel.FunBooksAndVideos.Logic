using System;
using System.Collections.Generic;
using System.Text;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Sipping;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.PurchaseOrder;
using Moq;
using Xunit;

namespace Emmanuel.FunBooksAndVideos.Test
{
    public class PurchaseOrderTest
    {
        [Fact]
        public void GivenCustomerId_EnsureTheProcessPurchaseOrderTaskIsCompleted()
        {
            //Arrange
            var customerId = 4;

            //Act
            var mockGetCustomersOrder = new Mock<IGetCustomersOrder>();
            var mockAccountDetails = new Mock<IAccountDetails>();
            var mockGenerateShippingSlip = new Mock<IGenerateShippingSlip>();

            var sut = new PurchaseOrderService(mockGetCustomersOrder.Object, mockAccountDetails.Object,
                mockGenerateShippingSlip.Object);

            var response = sut.ProcessPurchaseOrder(customerId);

            //Assert
            Assert.True(response.IsCompleted);
        }

        [Fact]
        public void GivenAnOrderRequest_CalculateTheTotalAmountShouldReturnTheCorrectValue()
        {
            //Arrange
            var orderRequest = OrderRequest();

            //Act
            var mockGetCustomersOrder = new Mock<IGetCustomersOrder>();
            var mockAccountDetails = new Mock<IAccountDetails>();
            var mockGenerateShippingSlip = new Mock<IGenerateShippingSlip>();

            var sut = new PurchaseOrderService(mockGetCustomersOrder.Object, mockAccountDetails.Object,
                mockGenerateShippingSlip.Object);

            var response = sut.CalculateTotalPrice(orderRequest);

            //Assert
            Assert.Equal(86, response);
        }

        public OrderRequest OrderRequest()
        {
            return new OrderRequest
            {
                Products = new ItemLines
                {
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Author = "Author Name",
                            Description = "The description of the book",
                            Isbn = "1234-5678-9023-123",
                            NumberOfPages = 2234,
                            Price = 10.00,
                            ProductId = 12345,
                            Title = "The title of the book",
                            ProductType = ProductType.Physical
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
                    },
                    Videos = new List<Video>
                    {
                        new Video
                        {
                            VideoFormat = ".MP4",
                            Description = "The description of the video",
                            Price = 10.00,
                            ProductId = 12346,
                            Title = "The title of the video",
                            ProductType = ProductType.Physical
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
                    },
                }
            };
        }
    }
}
