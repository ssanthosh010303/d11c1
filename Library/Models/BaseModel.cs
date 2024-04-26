/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Models;

public abstract class BaseModel : IEquatable<BaseModel>
{
    private int _id;
    private DateTime _createdAt = DateTime.Now;
    private DateTime _updatedAt = DateTime.Now;
    private bool _isActive = true;

    public int Id
    {
        get { return _id; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Id), "ID must be greater than zero.");

            _id = value;
        }
    }

    public DateTime CreatedAt
    {
        get { return _createdAt; }
    }

    public DateTime UpdatedAt
    {
        get { return _updatedAt; }
        set
        {
            if (UpdatedAt.CompareTo(value) <= 0)
                throw new ArgumentException("Time of updation must be after time of creation.");

            _updatedAt = DateTime.Now;
        }
    }

    public bool IsActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    public bool Equals(BaseModel? other) { return Id.Equals(other?.Id); }

    public override bool Equals(object? obj) { return Equals(obj as ProductModel); }

    public override int GetHashCode() { return Id; }

    public override string ToString()
    {
        string data = "";

        data += "----------------------------------------\n";
        data += $"Created on: {CreatedAt}\n";
        data += $"Updated on: {UpdatedAt}\n";
        data += $"Active:     {IsActive}\n";
        data += "----------------------------------------\n";

        return data;
    }
}
