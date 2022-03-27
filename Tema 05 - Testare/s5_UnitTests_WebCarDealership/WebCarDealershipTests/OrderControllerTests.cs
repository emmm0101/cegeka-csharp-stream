using CarDealership.Data;
using CarDealership.Data.Models;
using Moq;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCarDealershipTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;
        public OrderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }

        [Fact]
        public async Task GivenAValidRequestModel_WhenCallingPost_ThenGettingAResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Alex Model"
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenAnInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        {
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            //Act
            var result = await controllerSut.Post(requestModel); ;

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task GivenAnInvalidOrderModel_WhenCallingPost_ThenGetBadRequest()
        {
            // ??
            
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();
            controllerSut.ModelState.AddModelError("Quantity", "Range");


            //Act
            var result = await controllerSut.Post(requestModel); ;

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }


        [Fact]
        public async Task GivenABiggerQuantityThanStock_WhenCallingPost_ThenGetBadRequest()
        {

            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Alex Model",
                AvailableStock = 2

            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 3
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}