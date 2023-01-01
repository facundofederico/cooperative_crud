using System;
namespace Cooperative.Models;

public class Item
{
    // Gets the name of the item.
    public Guid Id { get; }

    // Gets the name of the item.
    public string Name { get; }

    // Gets a description for the item.
    public string Description { get; }

    // Gets the price of the item.
    public decimal Price { get; }


    public Item(string name, string description, decimal price)
        : this(Guid.NewGuid(), name, description, price)
    {
    }

    public Item(Guid id, string name, string description, decimal price)
    {
        if (name == "" || name.Length > 80)
        {
            throw new ArgumentException();
        }
        if (description == "")
        {
            throw new ArgumentException();
        }
        if (price < 0)
        {
            throw new ArgumentException();
        }

        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }
}