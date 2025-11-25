using BankSystem;

namespace BankTests;

public class SavingsAccountTests
{
    [Fact]
    public void ShouldCreateASavingsAccountWithInterestRate()
    {
        // Arrange...
        var account = new SavingsAccount(0.05M);

        // Assert...
        Assert.IsType<SavingsAccount>(account);
    }

    [Fact]
    public void ShouldReturnCorrectBalanceWithInterest()
    {
        // Arrange...
        var account = new SavingsAccount(0.10M);

        // Act...
        int amount = 1500;
        account.Deposit(amount);
        decimal balance = account.Balance;
        decimal calculatedBalance = amount * (1 + account.InterestRate);
        // Assert...
        Assert.Equal(calculatedBalance, balance);
    }

    [Fact]
    public void ShouldReturnCorrectBalanceWithOutInterest()
    {
        // Arrange...
        var account = new SavingsAccount(0.10M);

        // Act...
        int amount = 1000;
        account.Deposit(amount);
        decimal calculatedBalance = account.Balance;
        // Assert...
        Assert.Equal(calculatedBalance, account.Balance);
        // Assert...
    }
}
