/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Models;

public class CartItemModel : BaseModel
{
    private CartModel _cart;
    private ProductModel _product;
    private int _quantityOrdered;

    public CartItemModel(CartModel cart, ProductModel product, int quantityOrdered)
    {
        Cart = cart;
        Product = product;
        QuantityOrdered = quantityOrdered;
    }

    public CartModel Cart
    {
        get { return _cart; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Cart), "Cart entity cannot be null.");

            _cart = value;
        }
    }

    public ProductModel Product
    {
        get { return _product; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Product), "Product entity cannot be null.");

            _product = value;
        }
    }

    public int QuantityOrdered
    {
        get { return _quantityOrdered; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(QuantityOrdered), "Quantity must be greater than zero.");

            _quantityOrdered = value;
        }
    }

    public override string ToString()
    {
        string data = "";

        data += "----------------------------------------\n";
        data += $"CART ITEM: {Id}\n";
        data += "----------------------------------------\n";
        data += $"Product:          {Product.Name}\n";
        data += $"Ordered quantity: {QuantityOrdered}\n";
        data += $"Price:            {Product.Price:C}\n";
        data += $"In cart:          {Cart.Id}\n";
        data += base.ToString();

        return data;
    }
}
