using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.ViewModels
{
	public class SubscriptionRequestModel
	{
		[Required]
		public Guid UserId { get; set; }
		[Required]
		public int BookId { get; set; }
	}
}
