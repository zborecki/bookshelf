namespace Domain.Guards;

using System.Runtime.CompilerServices;

public static class StringGuard
{
    public static void ThrowIfNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} cannot be empty.");
        }
    }
    
    public static void ThrowIfLengthOutOfRange(string value, int minLength, int maxLength, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value.Length < minLength || value.Length > maxLength)
        {
            throw new ArgumentException($"{parameterName} must contain between {minLength} and {maxLength} characters.");
        }
    }
}