using Assessment.Domain.Contexts;
using Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Domain.UseCases.Subscriptions
{
	public sealed class GetAll : DomainUseCase<List<Subscription>>
	{
		public Guid UserId { get; set; }

		public GetAll(DomainContext domainContext)
		   : base(domainContext)
		{
		}

		protected override Tuple<bool, List<Subscription>> VerifyStateInternal()
		{
			return Tuple.Create(true, new List<Subscription>());
		}

		protected override Task<List<Subscription>> ExecuteInternal()
		{
			var repo = Context.Repository;
			return Task.FromResult(repo.All<Subscription>().Where(x => x.UserId == UserId).ToList());
		}
	}
}
