namespace domain;

public class Product(string itemNumber, string name, decimal price)
{
    public string ItemNumber { get; set; } = itemNumber;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;

    public void Update(string itemNumber, string name, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Namn saknas", nameof(name));
        }

        if (name.Length < 5)
        {
            throw new ArgumentException("Namn måste vara minst 5 tecken");
        }

        if (string.IsNullOrEmpty(itemNumber))
        {
            throw new ArgumentException("Artikelnummer saknas");
        }

        if (itemNumber.Length < 7)
        {
            throw new ArgumentException("Artikelnummer måste vara minst 7 tecken");
        }

        if (price < 0)
        {
            throw new ArgumentException("Pris kan inte vara lägre än 0");
        }
    }

    public bool Save()
    {
        return true;
    }
}
