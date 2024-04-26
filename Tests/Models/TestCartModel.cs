/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class CartModelTests
{
    private CartModel _cart;
    private CustomerModel _customer;
    private CartItemModel _cartItem;

    [SetUp]
    public void SetUp()
    {
        _customer = new("John Doe", "+91 52742 52136", 12);
        _cart = new CartModel(_customer);
        _cartItem = new(_cart, new("XYZ", 5, 100.00, 0.05, new DateTime(2024, 08, 01)), 5);
    }

    [Test]
    public void TestConstructorWithNullCustomerThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new CartModel(null));
    }

    [Test]
    public void TestConstructorWithValidCustomerSetsCustomerProperty()
    {
        Assert.That(_cart.Customer, Is.EqualTo(_customer));
    }

    [Test]
    public void TestCartItemsInitiallyEmpty()
    {
        Assert.That(_cart.CartItems, Is.Empty);
    }

    [Test]
    public void TestIndexerGetInvalidIndexThrowsIndexOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { var item = _cart[-1]; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { var item = _cart[_cart.CartItems.Count]; });
    }

    [Test]
    public void TestIndexerSetInvalidIndexThrowsIndexOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { _cart[-1] = _cartItem; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { _cart[_cart.CartItems.Count] = _cartItem; });
    }

    [Test]
    public void TestIndexerGetSetValidIndexReturnsCorrectCartItem()
    {
        _cart.CartItems.Add(_cartItem);
        Assert.That(_cart[0], Is.EqualTo(_cartItem));

        var newCartItem = _cartItem;

        _cart[0] = newCartItem;
        Assert.That(_cart[0], Is.EqualTo(newCartItem));
    }

    [Test]
    public void TestToStringIncludesCustomerDetailsAndCartItems()
    {
        _cart.CartItems.Add(_cartItem);

        string result = _cart.ToString();

        StringAssert.Contains("John Doe", result);
        StringAssert.Contains("+91 52742 52136", result);
        StringAssert.Contains(_cartItem.Product.Name, result);
    }
}
