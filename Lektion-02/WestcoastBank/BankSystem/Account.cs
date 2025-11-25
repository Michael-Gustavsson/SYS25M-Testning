namespace BankSystem;

public class Account
{

    public virtual decimal Balance { get; set; }
    public bool IsBlocked { get; set; }

    public Account()
    {
        Balance = 0;
    }
    public Account(int amount)
    {
        Balance = amount;
    }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (Balance < amount) throw new InvalidOperationException("Uttag medges ej!");
        Balance -= amount;
    }
}
