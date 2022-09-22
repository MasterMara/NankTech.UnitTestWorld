using System.Globalization;
using NankTech.SimpleCalculator.Tests.testParameter;

namespace NankTech.SimpleCalculator.Tests.theory;

public class CultureTestTheoryData : TheoryData<CultureTestParameter>
{
    public CultureTestTheoryData()
    {
        Add(new CultureTestParameter
        {
            Culture = CultureInfo.CreateSpecificCulture("tr-TR"),
            Actual = new DateTime(2017, 05, 15),
            Expected = "15 Mayıs 2017"
        });

        Add(new CultureTestParameter
        {
            Culture = CultureInfo.CreateSpecificCulture("en-US"),
            Actual = new DateTime(1987, 08, 13),
            Expected = "13 August 1987"
        });
    }
}