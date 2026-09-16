using Domain.Abstractions;

namespace Domain.ValueObjects;

public class BookTitle(string value) : Name(value, maxLength: 255);