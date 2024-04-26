/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Models;

public class ProductModel : BaseModel
{
    private string _name;
    private string? _imagePath;
    private int _quantityInStock;
    private int _minAge = 3;
    private double _price;
    private double _discount;
    private DateTime _discountExpiryDate;

    public ProductModel(string name, int quantityInStock, double price, double discount, DateTime priceExpiryDate)
    {
        Name = name;
        QuantityInStock = quantityInStock;
        Price = price;
        Discount = discount;
        DiscountExpiryDate = priceExpiryDate;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");

            _name = value;
        }
    }

    public string? ImagePath
    {
        get { return _imagePath; }
        set { _imagePath = value; }
    }

    public int QuantityInStock
    {
        get { return _quantityInStock; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(QuantityInStock), "Quantity in stock cannot be negative.");

            _quantityInStock = value;
        }
    }

    public int MinAge
    {
        get { return _minAge; }
        set
        {
            if (value < 3 || value > 150)
                throw new ArgumentOutOfRangeException(nameof(MinAge), "Invalid minimum age provided.");

            _minAge = value;
        }
    }

    public double Price
    {
        get { return _price; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Price), "Price cannot be negative.");

            _price = value;
        }
    }

    public double Discount
    {
        get { return _discount; }
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Discount), "Discount must be between zero and hundred.");

            _discount = value;
        }
    }

    public DateTime DiscountExpiryDate
    {
        get { return _discountExpiryDate; }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException(nameof(DiscountExpiryDate), "Price expiry date must be in the future.");

            _discountExpiryDate = value;
        }
    }

    public override string ToString()
    {
        string data = "";

        data += "----------------------------------------\n";
        data += $"PRODUCT: {Id}\n";
        data += "----------------------------------------\n";
        data += $"Product:          {Name}\n";
        data += $"In stock:         {QuantityInStock}\n";
        data += $"Price:            {Price}\n";
        data += $"Discount:         {Discount}\n";
        data += $"Price expiry:     {DiscountExpiryDate}\n";
        data += base.ToString();

        return data;
    }
}
