using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Core.Services.Subscribtions
{
	public class SubscriptionService : ISubscriptionService
	{
		private readonly ApplicationDBContext _context;

		public SubscriptionService(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(Guid UserId, int BookId)
		{
			try
			{
				var subscription = _context.Add(new Data.Entities.Subscription
				{
					UserId = UserId,
					BookId = BookId
				});

				_context.SaveChanges();
				return true;
			}
			catch(Exception)
			{
				return false;
			}
			
		}

		public bool Delete(Guid UserId, int BookId)
		{
			try
			{
				var subscription = _context.Subscriptions.FirstOrDefault(x => x.UserId == UserId && x.BookId == BookId);
				if (subscription == null)
				{
					return false;
				}
				_context.Remove(subscription);
				_context.SaveChanges();
				return true;
			}
			catch(Exception)
			{
				return false;
			}
}
		public IEnumerable<Data.Entities.Subscription> Get(Guid id)
		{
			return _context.Subscriptions.Where(x => x.UserId == id).ToList();
		}
	}
}
