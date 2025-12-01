namespace domain;

public class Product(string itemNumber, string name, decimal price)
{
    public string ItemNumber { get; set; } = itemNumber;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
}
