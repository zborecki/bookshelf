using Domain.Guards;

namespace Domain.Abstractions;

public abstract class Name(string value, int maxLength = 64, bool isRequired = true)
{
    public string Value { get; private set; } = Validate(value, maxLength, isRequired);
    
    public void Change(string value) => Value = Validate(value, maxLength, isRequired);

    private static string Validate(string value, int maxLength, bool isRequired)
    {
        if (isRequired) StringGuard.ThrowIfNullOrWhiteSpace(value);
        
        StringGuard.ThrowIfLengthOutOfRange(value, 1, maxLength);
        
        return value;
    }

    public override string ToString()
    {
        return Value;
    }
}