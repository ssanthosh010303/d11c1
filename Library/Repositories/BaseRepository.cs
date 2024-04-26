/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
using System.Reflection;

using Challenge1.Library.Exceptions;
using Challenge1.Library.Models;

namespace Challenge1.Library.Repositories;

public interface IBaseRepository<T> where T : BaseModel
{
    T GetById(int id);
    IList<T> GetAll();
    int GetCount();

    T Add(T obj);
    void Update(T obj);
    void Delete(T obj);

    T this[int index] { get; set; }
}

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected List<T> _entityList = [];

    public T GetById(int id)
    {
        return _entityList.Find(tAtIndex => tAtIndex.Id == id)
            ?? throw new ModelEntityNotFoundException();
    }

    public IList<T> GetAll() { return _entityList; }

    public int GetCount() { return _entityList.Count; }

    public T Add(T obj)
    {
        obj.Id = _entityList.Count + 1;

        _entityList.Add(obj);
        return obj;
    }

    public void Update(T obj)
    {
        T existingObject = _entityList.Find(tAtIndex => tAtIndex.Id == obj.Id)
            ?? throw new ModelEntityNotFoundException();
        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (PropertyInfo property in properties)
            property.SetValue(existingObject, property.GetValue(obj));
    }

    public void Delete(T obj)
    {
        if (!_entityList.Remove(obj)) throw new ModelEntityNotFoundException();
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _entityList.Count)
                throw new IndexOutOfRangeException();
            return _entityList[index];
        }
        set
        {
            if (index < 0 || index >= _entityList.Count)
                throw new IndexOutOfRangeException();
            _entityList[index] = value;
        }
    }
}
