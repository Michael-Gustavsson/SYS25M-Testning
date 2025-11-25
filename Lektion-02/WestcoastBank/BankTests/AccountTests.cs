using BankSystem;

namespace BankTests;

public class AccountTests
{
    [Fact]
    public void ShouldCreateCorrectAccountType()
    {
        // Arrange... 
        var account = new Account();

        // Act...???

        // Assert...???
        Assert.IsType<Account>(account);
    }

    [Fact]
    public void ShouldCreateAnAccountWithZeroBalance()
    {
        // Arrange...
        var account = new Account();

        // Act & Assert...
        // Kontrollera så att saldot är 0...
        var result = account.Balance;

        // Assert...
        Assert.Equal(0, result);

    }

    [Fact]
    public void ShouldCreateAnAccountWithCorrectInitializedBalance()
    {
        // Arrange...
        var account = new Account(500);

        // Act & Assert...
        // Kontrollera så att saldot är 0...
        var result = account.Balance;

        // Assert...
        Assert.Equal(500, result);

    }

    [Fact]
    public void ShouldIncreaseBalanceWhenDeposit()
    {
        // Arrange...
        var account = new Account();

        // Act...
        account.Deposit(200);
        var balance = account.Balance;
        // Assert...
        Assert.Equal(200, balance);
    }

    [Fact]
    public void ShouldIncreaseBalanceWhenWithdraw()
    {
        // Arrange...
        var account = new Account();

        // Act...
        account.Deposit(200);
        account.Withdraw(25);

        var balance = account.Balance;
        // Assert...
        Assert.Equal(175, balance);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenNotEnoughFunds()
    {
        // Arrange...
        var account = new Account();

        // Act...
        account.Deposit(100);

        // Assert...
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(200));
    }

    [Fact]
    public void ShouldBlockAccountWhenSetToTrue()
    {
        // Arrange...
        var account = new Account();

        // Act...
        account.IsBlocked = true;

        // Assert...
        Assert.True(account.IsBlocked);
    }

    [Fact]
    public void ShouldUnBlockAccountWhenSetToFalse()
    {
        // Arrange...
        var account = new Account();

        // Act...
        account.IsBlocked = false;

        // Assert...
        Assert.False(account.IsBlocked);
    }
}
