using Domain.ValueObjects;

namespace Tests.Domain.ValueObjects;

public class BookTitleTests
{
    [Fact]
    public void ShouldThrowExceptionWhenValueIsTooLong()
    {
        var value = new string('a', 256);
        
        Assert.Throws<ArgumentException>(() => new BookTitle(value));
    }
}