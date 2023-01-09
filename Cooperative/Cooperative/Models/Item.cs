using System.Reflection;
using Cooperative.Models.Exceptions;

namespace Cooperative.Models;

/// <summary>
/// Represents a product or service provided by an organization.
/// </summary>
public class Item
{
    /// <summary>
    /// Gets the id of the <see cref="Item">.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the name of the <see cref="Item">.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a description of the <see cref="Item">.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the price of the <see cref="Item">.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Creates a new <see cref="Item">.
    /// </summary>
    /// <param name="name">The <see cref="Item">'s name.</param>
    /// <param name="description">The <see cref="Item">'s description.</param>
    /// <param name="price">The <see cref="Item">'s price.</param>
    public Item(string name, string description, decimal price)
        : this(Guid.NewGuid(), name, description, price)
    {
    }

    /// <summary>
    /// Creates a new <see cref="Item">.
    /// </summary>
    /// <param name="id">The <see cref="Item">'s id.</param>
    /// <param name="name">The <see cref="Item">'s name. It cannot be empty not greater
    /// than 80 characters.</param>
    /// <param name="description">The <see cref="Item">'s description. It cannot be empty.</param>
    /// <param name="price">The <see cref="Item">'s price. It cannot be negative.</param>
    /// <exception cref="InvalidNameException"> Thrown if the privided
    /// name is invalid.
    /// <exception cref="InvalidDescriptionException"> Thrown if the privided
    /// description is invalid.
    /// <exception cref="InvalidPriceException"> Thrown if the privided
    /// price is invalid.
    /// </exception>
    public Item(Guid id, string name, string description, decimal price)
    {
        if (name == "" || name.Length > 80)
        {
            throw new InvalidNameException();
        }
        if (description == "")
        {
            throw new InvalidDescriptionException();
        }
        if (price < 0)
        {
            throw new InvalidPriceException();
        }

        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }
}