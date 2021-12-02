using Assessment.Domain.Contexts;
using Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Domain.UseCases.Books
{
	public sealed class GetAll : DomainUseCase<List<Book>>
	{

		public GetAll(DomainContext domainContext)
		   : base(domainContext)
		{
		}

		protected override Tuple<bool, List<Book>> VerifyStateInternal()
		{
			return Tuple.Create(true, new List<Book>());
		}

		protected override Task<List<Book>> ExecuteInternal()
		{
			var repo = Context.Repository;
			return Task.FromResult(repo.All<Book>().ToList());
		}
	}
}
