using Assessment.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Core.Services.Subscribtions
{
	public interface ISubscriptionService
	{
		IEnumerable<Data.Entities.Subscription> Get(Guid id);
		bool Add(Guid UserId, int BookId);
		bool Delete(Guid UserId, int BookId);
	}
}
