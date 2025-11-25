namespace BankSystem;

public class SavingsAccount(decimal interestRate) : Account
{
    public decimal InterestRate { get; set; } = interestRate;
    public override decimal Balance
    {
        get
        {
            if (base.Balance > 1000)
            {
                return base.Balance *= 1 + InterestRate;
            }
            else
            {
                return base.Balance;
            }
        }
        set => base.Balance = value;
    }
}
