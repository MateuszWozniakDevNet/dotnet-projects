using System.Globalization;

namespace EventPingApp.Presentation.Converters;

public class ValidationErrorsConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) 
        => value is IEnumerable<string> errors && errors.Any() ? string.Join(", ", errors) : string.Empty;
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
