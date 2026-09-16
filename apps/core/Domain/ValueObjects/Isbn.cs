using Domain.Guards;

namespace Domain.ValueObjects;

public class Isbn(string value)
{
    private string _value = Validate(value);

    public string GetIsbn() => _value;
    
    public void ChangeIsbn(string newIsbn) => _value = Validate(newIsbn);

    private static string Validate(string value)
    {
        StringGuard.ThrowIfNullOrWhiteSpace(value);
        StringGuard.ThrowIfLengthOutOfRange(value, 1, 20);
        
        return value;
    }

    public override string ToString()
    {
        return _value;
    }
}