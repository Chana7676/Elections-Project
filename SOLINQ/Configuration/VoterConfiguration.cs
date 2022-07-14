using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Elections.Classes;

namespace Elections.Configuration
{
    public class VoterConfiguration : IEntityTypeConfiguration<Voter>
    {
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.ToTable("Voters");

            builder.Property(b => b.Id)
                .HasColumnName("id");
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)");

            builder.Property(b => b.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(20)");

            builder.Property(b => b.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(b => b.Sex)
                .HasColumnName("sex")
                .IsRequired();

            builder.Property(b => b.City)
                .HasColumnName("city")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(b => b.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasColumnType("varchar(10)");

            builder.HasOne(b => b.Party)
                .WithMany(s => s.Voters)
                .HasForeignKey("party_id")
                .IsRequired();
        }
    }
}
