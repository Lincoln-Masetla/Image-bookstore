using Assessment.Domain.Contexts;
using Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Domain.UseCases.Subscriptions
{
	public sealed class Add : DomainUseCase<Subscription>
	{
		public int BookId { get; set; }
		public Guid UserId { get; set; }

		public Add(DomainContext domainContext)
		   : base(domainContext)
		{
		}

		protected override Tuple<bool, Subscription> VerifyStateInternal()
		{
			return Tuple.Create(true, new Subscription());
		}

		protected override Task<Subscription> ExecuteInternal()
		{
			var repo = Context.Repository;
			var subscription = new Subscription
			{
				UserId = UserId,
				BookId = BookId
			};
			repo.Add(subscription);

			repo.Commit();

			return Task.FromResult(subscription);
		}
	}
}
