using Assessment.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Core.Services.Books
{
	public class BookService : IBookService
	{
		private readonly ApplicationDBContext _context;

		public BookService(ApplicationDBContext context)
		{
			_context = context;
		}

		public IEnumerable<Book> GetAll()
		{
			return _context.Books.ToList();
		}
	}
}
