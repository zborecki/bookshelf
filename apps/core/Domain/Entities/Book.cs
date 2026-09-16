using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Book(string title) : Entity
{
    public BookTitle Title = new(title);
}