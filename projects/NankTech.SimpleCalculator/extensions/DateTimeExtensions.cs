using System.Globalization;

namespace NankTech.SimpleCalculator.extensions;

public static class DateTimeExtensions
{
    public static string ToPrettyDate(this DateTime date, CultureInfo culture)
    {
        if (culture == null)
        {
            throw new ArgumentNullException(nameof(culture));
        }

        return date.ToString("dd MMMMM yyyy", culture);
    }
}