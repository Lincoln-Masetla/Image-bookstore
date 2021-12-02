using Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Domain.EF.Mappings.Entities
{
	public sealed class BookMapping : EntityMapping<Book>
	{
		public override void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");
		}
	}
}
