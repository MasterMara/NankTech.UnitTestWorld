using System.Globalization;
using NankTech.SimpleCalculator.extensions;
using NankTech.SimpleCalculator.Tests.testParameter;
using NankTech.SimpleCalculator.Tests.theory;

namespace NankTech.SimpleCalculator.Tests;

public class DateTİmeExtensionsTest
{
    
    public static IEnumerable<object[]> StaticParameter => new List<CultureTestParameter[]>
    {
        new CultureTestParameter[]
        {
            new CultureTestParameter
            {
                Culture = CultureInfo.CreateSpecificCulture("it-IT"),
                Actual = new DateTime(1988, 06, 05),
                Expected = "05 giugno 1988"
            }
        }
    };
    
    [Fact]
    public void ToPrettyDate_Should_Throw_Argument_Null_Exception_When_Culture_Is_Null()
    {
        //Arrange
        const string expected = "culture";

        //Act
        var actualResult = Record.Exception(() => DateTime.Now.ToPrettyDate(null));
        var exception = Assert.IsType<ArgumentNullException>(actualResult);
        var actual = exception.ParamName;
        
        //Assert
        Assert.NotNull(actualResult);
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(new object[] { "de-DE", "2017.12.19", "19 Dezember 2017" })]
    public void ToPrettyDate_Should_Return_True_When_Culture_Is_German(string cultureCode, string textDate, string expected)
    {
        //Arrange
        var culture = CultureInfo.CreateSpecificCulture(cultureCode);
        var date = DateTime.ParseExact(textDate, "yyyy.MM.dd", culture);

        //Act
        var actualResult = date.ToPrettyDate(culture);

        //Assert
        Assert.Equal(expected, actualResult);
    }
    
    [Theory, MemberData(nameof(StaticParameter))]
    public void ToPrettyDate_ShouldAssertTrue_WhenCultureIsItalian(CultureTestParameter parameter)
    {
        //Arrange
        var expected = parameter.Expected;

        //Act
        var actual = parameter.Actual.ToPrettyDate(parameter.Culture);

        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [ClassData(typeof(CultureTestTheoryData))]
    public void ToPrettyDate_ShouldAssertsTrue_WhenCultureIsDefined(CultureTestParameter parameter)
    {
        //Arrange
        var expected = parameter.Expected;

        //Act
        var actual = parameter.Actual.ToPrettyDate(parameter.Culture);

        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [ClassData(typeof(ExceptionTestTheoryData))]
    public void Divide_Should_Asserts_True_When_Culture_Second_Value_Is_Zero(ExceptionTestParameter parameter)
    {
        var exceptionType = Assert.ThrowsAny<SystemException>(() => parameter.FirstValue / parameter.SecondValue);
        Assert.True(exceptionType.GetType().IsAssignableFrom(parameter.ExceptedException));
    }
    
    
}