using Domain.Guards;

namespace Domain.ValueObjects;

public class BookTitle(string value)
{
    private string _value = Validate(value);

    public string GetTitle() => _value;
    
    public void ChangeTitle(string newTitle) => _value = Validate(newTitle);

    private static string Validate(string value)
    {
        StringGuard.ThrowIfNullOrWhiteSpace(value);
        StringGuard.ThrowIfLengthOutOfRange(value, 1, 255);
        
        return value;
    }

    public override string ToString()
    {
        return _value;
    }
}