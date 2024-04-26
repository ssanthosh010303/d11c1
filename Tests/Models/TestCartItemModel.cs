/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class CartItemModelTests
{
    private readonly CustomerModel _customer = new("Sakthi Santhosh", "+91 637-9921036", 15);
    private readonly ProductModel _product = new("XYZ", 100, 100.00, 0.05, new DateTime(2024, 08, 01));

    [Test]
    public void TestCartItemModelConstructWithValidArgumentsSuccess()
    {
        CartModel cart = new(_customer);
        int quantityOrdered = 5;
        var cartItem = new CartItemModel(cart, _product, quantityOrdered);

        Assert.Multiple(() =>
        {
            Assert.That(cartItem.Cart, Is.EqualTo(cart));
            Assert.That(cartItem.Product, Is.EqualTo(_product));
            Assert.That(cartItem.QuantityOrdered, Is.EqualTo(quantityOrdered));
        });

    }

    [Test]
    public void TestCartItemModelConstructWithNullCartThrowsArgumentNullException()
    {
        int quantityOrdered = 5;

        Assert.Throws<ArgumentNullException>(() =>
        {
            new CartItemModel(null, _product, quantityOrdered);
        }, "Cart entity cannot be null.");
    }

    [Test]
    public void TestCartItemModelConstructWithNullProductThrowsArgumentNullException()
    {
        int quantityOrdered = 5;

        Assert.Throws<ArgumentNullException>(() =>
        {
            new CartItemModel(new(_customer), null, quantityOrdered);
        }, "Product entity cannot be null.");
    }

    [Test]
    public void TestCartItemModelSetQuantityOrderedWithNegativeValueThrowsArgumentOutOfRangeException()
    {
        var cartItem = new CartItemModel(new(_customer), _product, 5);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            cartItem.QuantityOrdered = -1;
        }, "Quantity must be greater than zero.");
    }
}
