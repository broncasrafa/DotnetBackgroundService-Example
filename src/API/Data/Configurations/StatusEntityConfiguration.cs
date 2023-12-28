using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class StatusEntityConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("tbStatus");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Descricao).HasColumnName("Descricao");
    }
}