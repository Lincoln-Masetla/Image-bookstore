using Assessment.Core.Data.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Core.Tests.Books
{
	using static Testing;
	public class BookServiceTests : TestBase
	{
		[Test]
		public void GetAll_Empty_ShouldReturnListOfBooks()
		{
			// Arrange
			var book = CreateBook(new Book
			{
				Description = Guid.NewGuid().ToString(),
				Title = Guid.NewGuid().ToString(),
			});

			// Act
			var result = GetAllBooks();

			// Assert
			var savedBook = result.FirstOrDefault(x => x.Id == book.Id);
			savedBook.Should().NotBeNull();
			savedBook.Title.Should().Be(book.Title);
			savedBook.Description.Should().Be(book.Description);
		}
	}
}
