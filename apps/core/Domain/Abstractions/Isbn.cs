namespace Domain.Abstractions;

public abstract class Isbn(string value)
{
    public string Value { get; } = value;

    public abstract bool IsValid();

    protected static string Normalize(string value)
    {
        var normalized = value.Where(c => c != '-' && !char.IsWhiteSpace(c)).ToArray();
        
        return new string(normalized);
    }
}