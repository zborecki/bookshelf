using Domain.Entities;

var book = new Book("Harry Potter: Prisoner of Azkaban", "ABC");
Console.WriteLine(book.Title);

book.Title.ChangeTitle("Harry Potter: Deathly Hallows");
Console.WriteLine(book.Title);