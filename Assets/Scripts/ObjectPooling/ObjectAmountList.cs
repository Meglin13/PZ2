using System;
using System.Collections.Generic;
using TreeEditor;

[Serializable]
public class ObjectAmountList<T> where T : class
{
    public List<ObjectAmountElement<T>> list;

    private int capacity;
    public int Capacity => capacity;

    public List<T> GetList()
    {
        var list = new List<T>();

        foreach (var element in this.list)
            list.AddRange(element.GetItems());

        return list;
    }

    public void Add(T item, int amount) => list.Add(new(item, amount));

    public int Count => list.Count;

    public ObjectAmountElement<T> this[int index]
    {
        get => list[index];
        set => list[index] = value;
    }
}

[Serializable]
public class ObjectAmountElement<T> where T : class
{
    public T item;
    public int amount = 1;

    public ObjectAmountElement(T item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public List<T> GetItems()
    {
        var list = new List<T>();

        for (int i = 0; i < amount; i++)
            list.Add(item);

        return list;
    }
}