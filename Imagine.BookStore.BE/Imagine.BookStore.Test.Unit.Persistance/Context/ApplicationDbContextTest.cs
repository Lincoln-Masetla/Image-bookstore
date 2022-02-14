using Imagine.BookStore.Domain.Entities;
using Imagine.BookStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Imagine.BookStore.Test.Unit.Persistance.Context
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertSubscriptionIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var subscription = new Subscription();
            context.Subscriptions.Add(subscription);
            Assert.AreEqual(EntityState.Added, context.Entry(subscription).State);
        }

        [Test]
        public void CanDeleteSubscriptionIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var subscription = new Subscription();
            context.Subscriptions.Remove(subscription);
            Assert.AreEqual(EntityState.Deleted, context.Entry(subscription).State);
        }
    }
}
