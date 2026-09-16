using Domain.Abstractions;

namespace Tests.Domain.Abstractions;

public class NameTests
{
    private class Test(string value) : Name(value, maxLength: 64);
    
    [Fact]
    public void ShouldThrowExceptionWhenValueIsNull()
    {
        Assert.Throws<ArgumentException>(() => new Test(null!));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new Test(string.Empty));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsWhiteSpace()
    {
        Assert.Throws<ArgumentException>(() => new Test("  "));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsTooLong()
    {
        var value = new string('a', 100);
        
        Assert.Throws<ArgumentException>(() => new Test(value));
    }

    [Fact]
    public void ShouldReturnValueWhenNameIsValid()
    {
        const string value = "Hello!";
        var name = new Test(value);
        
        Assert.Equal(value, name.Value);
    }

    [Fact]
    public void ShouldUpdateValueWhenNameIsValid()
    {
        const string oldValue = "Hot";
        var name = new Test(oldValue);
        
        name.Change("Dog");
        
        Assert.NotEqual(oldValue, name.Value);
    }

    [Fact]
    public void ShouldReturnNameWhenToStringIsCalled()
    {
        const string value = "Hello world!";
        var name = new Test(value);
        
        Assert.Equal(value, name.ToString());
    }
}