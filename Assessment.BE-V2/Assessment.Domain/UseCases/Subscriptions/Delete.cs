using Assessment.Domain.Contexts;
using Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Domain.UseCases.Subscriptions
{
	public sealed class Delete : DomainUseCase<bool>
	{
		public int BookId { get; set; }
		public Guid UserId { get; set; }

		public Delete(DomainContext domainContext)
		   : base(domainContext)
		{
		}

		protected override Tuple<bool, bool> VerifyStateInternal()
		{
			return Tuple.Create(true, true);
		}

		protected override Task<bool> ExecuteInternal()
		{
			var repo = Context.Repository;
			var subscription =  repo.All<Subscription>().FirstOrDefault(x => x.BookId == BookId && x.UserId == UserId);
			if (subscription == null)
				return Task.FromResult(false);

			repo.Delete(subscription);
			repo.Commit();
			return Task.FromResult(true);
		}
	}
}
