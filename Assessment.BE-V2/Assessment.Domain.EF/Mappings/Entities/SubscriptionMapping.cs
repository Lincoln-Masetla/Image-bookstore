using Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Domain.EF.Mappings.Entities
{
	public sealed class SubscriptionMapping : EntityMapping<Subscription>
	{
		public override void Configure(EntityTypeBuilder<Subscription> builder)
		{
			builder.ToTable("Subscriptions");
		}
	}
}
