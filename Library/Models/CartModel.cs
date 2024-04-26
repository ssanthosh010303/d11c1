/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Models;

public class CartModel : BaseModel
{
    private CustomerModel _customer;
    private readonly List<CartItemModel> _cartItems = [];

    public CartModel(CustomerModel customer) { Customer = customer; }

    public CustomerModel Customer
    {
        get { return _customer; }
        set { _customer = value ?? throw new ArgumentNullException(nameof(Customer), "Customer cannot be null."); }
    }

    public List<CartItemModel> CartItems
    {
        get { return _cartItems; }
    }

    public CartItemModel this[int index]
    {
        get { return _cartItems[index]; }
        set { _cartItems[index] = value; }
    }

    public override string ToString()
    {
        string data = "";

        data += "----------------------------------------\n";
        data += $"CART: {Id}\n";
        data += "----------------------------------------\n";
        data += $"Customer name:   {Customer.Name}\n";
        data += $"Contact:         {Customer.Phone}\n";
        data += "----------------------------------------\n\n";

        foreach (CartItemModel cartItem in _cartItems)
            data += $"    * {cartItem.Product.Name} - {cartItem.QuantityOrdered}\n";

        data += "\n";
        data += base.ToString();

        return data;
    }
}
