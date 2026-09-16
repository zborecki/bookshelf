namespace Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public override string ToString()
    {
        return Id.ToString();
    }
}