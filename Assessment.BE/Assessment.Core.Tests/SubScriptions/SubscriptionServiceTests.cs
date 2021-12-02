using Assessment.Core.Data.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Core.Tests.Subscriptions
{
	using static Testing;
	public class SubscriptionServiceTests : TestBase
	{
		[Test]
		public void Subscribe_UserIdBookId_ShouldCreateASubscription()
		{
			// Arrange
			var book = CreateBook(new Book
			{
				Description = Guid.NewGuid().ToString(),
				Title = Guid.NewGuid().ToString(),
			});
			var user = new IdentityUser
			{
				Email = $"{Guid.NewGuid()}@test.com",
				UserName = Guid.NewGuid().ToString()
			};
			var password = Guid.NewGuid().ToString();

			var identityResult = CreateUserAsync(user, password);

			var identityUser = GetUserAsync(user.UserName);
			var userId = ToGuid(identityUser.Id);
			// Act
			CreateSubscription(userId, book.Id);

			// Assert
			var subscription = GetSubscriptions(userId).FirstOrDefault(x => x.BookId == book.Id);
			subscription.Should().NotBeNull();
		}
		[Test]
		public void UnSubscribe_UserIdBookId_ShouldCreateASubscription()
		{
			// Arrange
			var book = CreateBook(new Book
			{
				Description = Guid.NewGuid().ToString(),
				Title = Guid.NewGuid().ToString(),
			});
			var user = new IdentityUser
			{
				Email = $"{Guid.NewGuid()}@test.com",
				UserName = Guid.NewGuid().ToString()
			};
			var password = Guid.NewGuid().ToString();

			var identityResult = CreateUserAsync(user, password);

			var identityUser = GetUserAsync(user.UserName);
			var userId = ToGuid(identityUser.Id);
			CreateSubscription(userId, book.Id);
			// Act
			DeleteSubscription(userId, book.Id);

			// Assert
			var subscription = GetSubscriptions(userId).FirstOrDefault(x => x.BookId == book.Id);
			subscription.Should().BeNull();
		}
		[Test]
		public void GetAll_UserId_ShouldRetturnAListOfSubscription()
		{
			// Arrange
			var book = CreateBook(new Book
			{
				Description = Guid.NewGuid().ToString(),
				Title = Guid.NewGuid().ToString(),
			});
			var user = new IdentityUser
			{
				Email = $"{Guid.NewGuid()}@test.com",
				UserName = Guid.NewGuid().ToString()
			};
			var password = Guid.NewGuid().ToString();

			var identityResult = CreateUserAsync(user, password);

			var identityUser = GetUserAsync(user.UserName);
			var userId = ToGuid(identityUser.Id);
			CreateSubscription(userId, book.Id);

			// Act
			var subscriptions = GetSubscriptions(userId);

			// Assert
			var subscription = subscriptions.FirstOrDefault(x => x.BookId == book.Id);
			subscription.Should().NotBeNull();
		}

		private static Guid ToGuid(int value)
		{
			byte[] bytes = new byte[16];
			BitConverter.GetBytes(value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}

	}
}
