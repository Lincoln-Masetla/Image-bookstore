using Imagine.BookStore.Domain.Entities;
using NUnit.Framework;
using System;

namespace Imagine.BookStore.Test.Unit.Domain.Entities
{
    public class SubscriptionTests
    {
        private readonly Subscription _subscription;
        private readonly Guid Id = Guid.NewGuid();
        private readonly Guid BookId = Guid.NewGuid();
        private readonly Guid UserId = Guid.NewGuid();

        public SubscriptionTests()
        {
            _subscription = new Subscription();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _subscription.Id = Id;
            Assert.That(_subscription.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetBookId()
        {
            _subscription.BookId = BookId;
            Assert.That(_subscription.BookId, Is.EqualTo(BookId));
        }
        [Test]
        public void TestSetAndGetUserId()
        {
            _subscription.UserId = UserId;
            Assert.That(_subscription.UserId, Is.EqualTo(UserId));
        }
    }
}
