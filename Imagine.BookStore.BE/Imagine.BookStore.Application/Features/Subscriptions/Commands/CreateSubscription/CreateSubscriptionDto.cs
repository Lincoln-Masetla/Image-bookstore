using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks
{
    public class CreateSubscriptionDto
    {
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid BookId { get; set; }
	}
}
