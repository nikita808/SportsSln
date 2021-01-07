using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void CanUseRepository()
        {
            // Arrange

            var mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"}
            }.AsQueryable());

            var controller = new HomeController(mock.Object);

            // Act

            var result = controller.Index().ViewData.Model as IEnumerable<Product>;

            // Assert
            var prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }
    }
}