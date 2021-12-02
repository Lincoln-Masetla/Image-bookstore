using Assessment.Core.Data.Entities;
using System.Collections.Generic;

namespace Assessment.Core.Services.Books
{
	public interface IBookService
	{
		IEnumerable<Book> GetAll();
	}
}
