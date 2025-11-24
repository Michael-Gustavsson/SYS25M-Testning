using Calculator;

namespace CalculatorTests;

public class CalculateTest
{
    // Testar addition...
    [Fact]
    public void ShouldAddTwoNumbers()
    {
        // Arrange...
        var calculator = new Calc();

        // Act...
        var result = calculator.Add(2, 2);

        // Assert...
        Assert.Equal(4, result);
    }

    // Testar substraction...
    [Fact]
    public void ShouldSubtractTwoNumbers()
    {
        // Arrange...
        var calculator = new Calc();

        // Act...
        var result = calculator.Subtract(2, 1);

        // Assert...
        Assert.Equal(1, result);
    }

    // Test multiplation...

}
