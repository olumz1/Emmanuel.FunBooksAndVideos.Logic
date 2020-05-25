using System;
using System.Collections.Generic;
using System.Text;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.Shipping;
using Moq;
using Xunit;

namespace Emmanuel.FunBooksAndVideos.Test
{
    public class ShippingSlipTest
    {
        [Fact]
        public void GIvenOrderRequestAndCustomerAccountDetails_ConfirmGenerateHippingSlipIsCalled()
        {
            //Arrange
            var orderRequest = new OrderRequest
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
                        }
                    },
                }
            };

            var customerAccount = new CustomerAccount
            {
                FirstName = "Joe",
                LastName = "Blogs",
                CustomerId = 4,
                Email = "joe.blogs@email.com"
            };

            //Act
           var sut = new GenerateShippingSlip();

            try
            {
                sut.GenerateSlippingSlip(orderRequest, customerAccount);

                //Assert
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
