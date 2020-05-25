using System;
using System.Collections.Generic;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Interfaces.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model;
using Emmanuel.FunBooksAndVideo.Logic.Model.Account;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using Emmanuel.FunBooksAndVideo.Logic.Services.Account;
using Moq;
using Xunit;

namespace Emmanuel.FunBooksAndVideos.Test
{
    public class AccountDetails
    {
        [Fact]
        public void GivenCustomerId_ReturnCustomerAccountDetails()
        {
            //Arrange
            var customerId = 4;

            var result = new CustomerAccount
            {
                FirstName = "Joe",
                LastName = "Blogs",
                CustomerId = 4,
                Email = "joe.blogs@email.com"
            };

            var moqAccountDetails = new Mock<IAccountDetails>();

            moqAccountDetails.Setup(x => x.GetCustomerAccountDetails(It.IsAny<int?>())).ReturnsAsync(result);

            //Act
            var sut = new BogusAccountDetails();

            var response = sut.GetCustomerAccountDetails(customerId).Result;

            //Assert
            Assert.Equal(result.CustomerId, response.CustomerId);
            
        }

        [Fact]
        public void GivenOrderRequest_DetermineCustomersMembership()
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

            //Act
            var moqAccountDetails = new Mock<IAccountDetails>();

            var sut = new BogusAccountDetails();

            var response = sut.DetermineCustomerMembership(orderRequest).Result;

           // Assert

            Assert.Equal(MembershipType.Premium, response);
        }

        [Fact]
        public void GivenPurchaseOrder_UpdateCustomerAccountDetailsIsComplete()
        {
            //Arrange
            var purchaseOrderModel = new PurchaseOrderModel
            {
                CustomerId = 4,
                PurchaseOrderId = 12345,
                Total = 112,
                ItemLine = new ItemLines
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
                    MembershipType = MembershipType.Premium
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
            var moqAccountDetails = new Mock<IAccountDetails>();

            var sut = new BogusAccountDetails();

            moqAccountDetails.Setup(x => x.GetCustomerAccountDetails(purchaseOrderModel.CustomerId)).ReturnsAsync(customerAccount);

            var response = sut.UpdateCustomerAccountDetails(purchaseOrderModel);

            //Assert
            Assert.True(response.IsCompleted);

        }
    }
}
