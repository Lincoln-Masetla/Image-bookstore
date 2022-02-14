namespace Imagine.BookStore.Domain.Entities;
public class Subscription
{
	public Subscription()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public Guid BookId { get; set; }

}
