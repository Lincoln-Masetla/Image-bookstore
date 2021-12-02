using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Core.Data.Entities
{
	public class Subscription
	{
		public Subscription()
		{
			CreatedDate = DateTime.Now;
			UpdatedDate = DateTime.Now;
		}

		public int Id { get; set; }
		public Guid UserId { get; set; }
		public int BookId { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }

	}
}
