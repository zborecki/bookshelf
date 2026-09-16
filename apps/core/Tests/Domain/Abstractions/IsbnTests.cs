using Domain.Abstractions;

namespace Tests.Domain.Abstractions;

public class IsbnTests
{
    private class Test(string value) : Isbn(value)
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
        
        public new static string Normalize(string value) => Isbn.Normalize(value);
    }

    [Theory]
    [InlineData("978-83-12345-67-8", "9788312345678")]
    [InlineData(" 978-83 12345-67 8 ", "9788312345678")]
    [InlineData("9788312345678", "9788312345678")]
    [InlineData("--- ", "")]
    public void ShouldRemoveHyphensAndWhiteSpaces(string value, string expected)
    {
        var result = Test.Normalize(value);
        
        Assert.Equal(expected, result);
    }
}