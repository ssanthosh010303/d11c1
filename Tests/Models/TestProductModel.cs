/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class ProductModelTests
{
    [Test]
    public void TestConstructorWithValidParametersInitializesProperties()
    {
        var discountExpiryDate = DateTime.Now.AddDays(10);
        var product = new ProductModel("Toy", 100, 29.99, 10, discountExpiryDate);

        Assert.Multiple(() =>
        {
            Assert.That(product.Name, Is.EqualTo("Toy"));
            Assert.That(product.QuantityInStock, Is.EqualTo(100));
            Assert.That(product.Price, Is.EqualTo(29.99));
            Assert.That(product.Discount, Is.EqualTo(10));
            Assert.That(product.DiscountExpiryDate, Is.EqualTo(discountExpiryDate));
        });

    }

    [TestCase(null)]
    [TestCase("")]
    public void TestNameSetInvalidValueThrowsArgumentNullException(string? name)
    {
        var product = new ProductModel("Valid Name", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentNullException>(() => product.Name = name);
    }

    [Test]
    public void TestQuantityInStockSetNegativeValueThrowsArgumentOutOfRangeException()
    {
        var product = new ProductModel("Toy", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentOutOfRangeException>(() => product.QuantityInStock = -1);
    }

    [TestCase(2)]
    [TestCase(151)]
    public void TestMinAgeSetInvalidValueThrowsArgumentOutOfRangeException(int age)
    {
        var product = new ProductModel("Toy", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentOutOfRangeException>(() => product.MinAge = age);
    }

    [Test]
    public void TestPriceSetNegativeValueThrowsArgumentOutOfRangeException()
    {
        var product = new ProductModel("Toy", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentOutOfRangeException>(() => product.Price = -1);
    }

    [TestCase(-1)]
    [TestCase(101)]
    public void TestDiscountSetInvalidValueThrowsArgumentOutOfRangeException(double discount)
    {
        var product = new ProductModel("Toy", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentOutOfRangeException>(() => product.Discount = discount);
    }

    [Test]
    public void TestDiscountExpiryDateSetPastDateThrowsArgumentException()
    {
        var product = new ProductModel("Toy", 10, 20.0, 5, DateTime.Now.AddDays(1));

        Assert.Throws<ArgumentException>(() => product.DiscountExpiryDate = DateTime.Now.AddDays(-1));
    }

    [Test]
    public void TestToStringReturnsFormattedStringContainsCorrectInformation()
    {
        var discountExpiryDate = DateTime.Now.AddDays(10);
        var product = new ProductModel("Toy", 100, 29.99, 10, discountExpiryDate);
        var result = product.ToString();

        StringAssert.Contains("Toy", result);
        StringAssert.Contains("100", result);
        StringAssert.Contains("29.99", result);
        StringAssert.Contains("10", result);
        StringAssert.Contains(discountExpiryDate.ToString(), result);
    }
}
