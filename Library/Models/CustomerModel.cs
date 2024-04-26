/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Models;

public class CustomerModel : BaseModel
{
    private string _name;
    private string _phone;
    private int _age;

    public CustomerModel(string name, string phone, int age)
    {
        Name = name;
        Phone = phone;
        Age = age;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(Name), "Name cannot be null or empty.");

            _name = value;
        }
    }

    public string Phone
    {
        get { return _phone; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(Phone), "Phone cannot be null or empty.");

            if (value.Length > 15)
                throw new ArgumentException("Invalid phone number format.", nameof(Phone));

            _phone = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be negative.");

            _age = value;
        }
    }

    public override string ToString()
    {
        string data = "";

        data += "----------------------------------------\n";
        data += $"CUSTOMER: {Id}\n";
        data += "----------------------------------------\n";
        data += $"Name:  {Name}\n";
        data += $"Phone: {Phone}\n";
        data += $"Age:   {Age}\n";
        data += base.ToString();

        return data;
    }
}
