namespace Imagine.BookStore.Domain.Entities;
public class Book
{
    public Book()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal PurchasePrice { get; set; }
}
