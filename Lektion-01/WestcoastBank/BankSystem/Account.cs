namespace BankSystem;

public class Account
{
    public int Balance { get; set; }
    public Account()
    {
        this.Balance = 0;
    }
    public Account(int amount)
    {
        this.Balance = amount;
    }

    public void Deposit(int amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(int amount)
    {
        this.Balance -= amount;
    }
}
