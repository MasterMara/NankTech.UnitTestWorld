namespace NankTech.SimpleCalculator.Tests;

public class SimpleCalculatorTest
{
    [Theory]
    [InlineData(10,20,30)]
    public void Calculator_Should_Addition_When_Two_Integer_Number_Comes(int number1, int number2, int expected)
    {
        //Naming Convention: MethodName_Should_Expected_When_Condition

        //Arrange
        var myCalculator = new Calculator();

        //Act
        var actual = myCalculator.Addition(number1, number2);


        //Assert
        Assert.Equal(expected, actual);

    }
}