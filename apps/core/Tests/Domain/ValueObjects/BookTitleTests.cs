using Domain.ValueObjects;

namespace Tests.Domain.ValueObjects;

public class BookTitleTests
{
    [Fact]
    public void ShouldThrowExceptionWhenValueIsNull()
    {
        Assert.Throws<ArgumentException>(() => new BookTitle(null!));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new BookTitle(string.Empty));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsWhiteSpace()
    {
        Assert.Throws<ArgumentException>(() => new BookTitle("  "));
    }

    [Fact]
    public void ShouldThrowExceptionWhenValueIsTooLong()
    {
        var value = new string('a', 256);
        
        Assert.Throws<ArgumentException>(() => new BookTitle(value));
    }

    [Fact]
    public void ShouldReturnValueWhenTitleIsValid()
    {
        const string value = "Test";
        var title = new  BookTitle(value);
        
        Assert.Equal(value, title.GetTitle());
    }

    [Fact]
    public void ShouldUpdateValueWhenTitleIsValid()
    {
        const string oldValue = "Test";
        var title = new BookTitle(oldValue);
        
        title.ChangeTitle("New Title");
        
        Assert.NotEqual(oldValue, title.GetTitle());
    }

    [Fact]
    public void ShouldReturnTitleWhenToStringIsCalled()
    {
        const string value = "Test";
        var title = new BookTitle(value);
        
        Assert.Equal(value, title.ToString());
    }
}