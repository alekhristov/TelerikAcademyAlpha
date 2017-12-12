using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cosmetics.UnitTests.CosmeticsFactoryTest
{
    [TestClass]
    public class CreateToothpaste_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeProductToothpaste()
        {
            // Arrange, Act, Assert
            var factory = new CosmeticsFactory();

            // Act
            var product = factory.CreateToothpaste("name", "brand", 10, GenderType.Unisex, "calcium,fluorid".Select(x => x.ToString()).ToList());

            // Assert
            Assert.IsInstanceOfType(product, typeof(IProduct));
        }
    }
}
