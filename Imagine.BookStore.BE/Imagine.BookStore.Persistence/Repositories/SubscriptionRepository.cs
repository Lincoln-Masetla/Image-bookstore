using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Entities;
using Imagine.BookStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.BookStore.Persistence.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Subscription> GetSubscriptionsByUserIdAndBookId(Guid UserId, Guid BookId)
        {
            return await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.UserId == UserId && x.BookId == BookId);
        }
    }
}
