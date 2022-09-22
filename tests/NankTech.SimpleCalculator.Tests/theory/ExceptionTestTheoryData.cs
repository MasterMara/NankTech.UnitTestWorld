using NankTech.SimpleCalculator.Tests.testParameter;

namespace NankTech.SimpleCalculator.Tests.theory;

public class ExceptionTestTheoryData : TheoryData<ExceptionTestParameter>
{
    public ExceptionTestTheoryData()
    {
        Add(new ExceptionTestParameter
        {
            FirstValue = 15,
            SecondValue = 0,
            ExceptedException = typeof(DivideByZeroException)
        });
    }
}