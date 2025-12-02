namespace domain;

public class Customer
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";

    public bool Save()
    {
        if (FirstName.Length > 0 && LastName.Length > 0 && Email.Length > 0)
        {
            return true;
        }

        throw new ArgumentException("Information saknas");
    }
}
