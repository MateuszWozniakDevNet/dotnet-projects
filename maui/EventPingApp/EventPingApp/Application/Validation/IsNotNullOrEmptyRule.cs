using Plugin.ValidationRules.Interfaces;

namespace EventPingApp.Application.Validation;

public class IsNotNullOrEmptyRule : IValidationRule<string>
{
    public string? ValidationMessage { get; set; }
    public bool Check(string value) => !string.IsNullOrWhiteSpace(value);
}
