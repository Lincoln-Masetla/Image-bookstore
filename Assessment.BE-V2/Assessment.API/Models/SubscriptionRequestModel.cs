using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment.API.Models
{
	public class SubscriptionRequestModel
	{
		[Required]
		public Guid UserId { get; set; }
		[Required]
		public int BookId { get; set; }
	}
}
