using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Elections.Classes;

namespace Elections.Configuration
{
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.ToTable("Parties");

            builder.Property(b => b.Id)
                .HasColumnName("id");
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(100)");

            builder.Property(b => b.Image)
                .HasColumnName("image")
                .HasColumnType("varchar(200)");

            builder.Property(b => b.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(50)");

        }
    }
}
