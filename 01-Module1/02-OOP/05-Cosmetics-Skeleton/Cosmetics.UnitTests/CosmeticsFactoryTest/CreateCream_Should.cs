using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.UnitTests.CosmeticsFactoryTest
{
    [TestClass]
    public class CreateCream_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeProduct()
        {
            // Arrange, Act, Assert
            var factory = new CosmeticsFactory();

            // Act
            var product = factory.CreateCream("name", "brand", 10, GenderType.Unisex, ScentType.Rose);

            // Assert
            Assert.IsInstanceOfType(product, typeof(IProduct));
        }
    }
}
