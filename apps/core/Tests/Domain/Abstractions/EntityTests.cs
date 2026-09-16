using Domain.Abstractions;

namespace Tests.Domain.Abstractions;

public class EntityTests
{
    private class TestEntity : Entity {}

    [Fact]
    public void ShouldGenerateNonEmptyId()
    {
        var entity = new TestEntity();
        
        Assert.NotEqual(Guid.Empty, entity.Id);
    }

    [Fact]
    public void ShouldGenerateUniqueIdForEachEntity()
    {
        var entity1 = new TestEntity();
        var entity2 = new TestEntity();
        
        Assert.NotEqual(entity1.Id, entity2.Id);
    }

    [Fact]
    public void ShouldReturnIdentifierAsString()
    {
        var entity = new TestEntity();
        var result = entity.ToString();
        
        Assert.Equal(entity.Id.ToString(), result);
    }
}