/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class CustomerModelTests
{
    [Test]
    public void TestConstructorWithValidParametersInitializesProperties()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Multiple(() =>
        {
            Assert.That(customer.Name, Is.EqualTo("John Doe"));
            Assert.That(customer.Phone, Is.EqualTo("+91 12345 98756"));
            Assert.That(customer.Age, Is.EqualTo(30));
        });

    }

    [Test]
    public void TestNameSetNullThrowsArgumentException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentException>(() => customer.Name = null);
    }

    [Test]
    public void TestNameSetEmptyThrowsArgumentException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentException>(() => customer.Name = "");
    }

    [Test]
    public void TestPhoneSetNullThrowsArgumentException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentException>(() => customer.Phone = null);
    }

    [Test]
    public void TestPhoneSetEmptyThrowsArgumentException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentException>(() => customer.Phone = "");
    }

    [Test]
    public void TestPhoneSetInvalidFormatThrowsArgumentException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentException>(() => customer.Phone = "+91 125648 45214587");
    }

    [Test]
    public void TestAgeSetNegativeThrowsArgumentOutOfRangeException()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);

        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Age = -1);
    }

    [Test]
    public void TestToStringReturnsFormattedStringContainsCorrectInformation()
    {
        var customer = new CustomerModel("John Doe", "+91 12345 98756", 30);
        var result = customer.ToString();

        StringAssert.Contains("John Doe", result);
        StringAssert.Contains("+91 12345 98756", result);
        StringAssert.Contains("30", result);
    }
}
