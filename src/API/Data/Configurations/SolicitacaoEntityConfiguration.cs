using System.Reflection.Emit;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public class SolicitacaoEntityConfiguration : IEntityTypeConfiguration<SolicitacaoEntity>
{
    public void Configure(EntityTypeBuilder<SolicitacaoEntity> builder)
    {
        builder.ToTable("tbSolicitacao");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataSolicitacao).HasColumnName("DataSolicitacao").HasColumnType("datetime2");
        builder.Property(c => c.Documento).HasColumnName("Documento");
        builder.Property(c => c.IdUsuario).HasColumnName("IdUsuario");
        builder.Property(c => c.IdStatus).HasColumnName("IdStatus");

        builder.Property(c => c.DataInicioProcessamento1).HasColumnName("DataProcessamento_1_Inicio").HasColumnType("datetime2");
        builder.Property(c => c.DataFimProcessamento1).HasColumnName("DataProcessamento_1_Fim").HasColumnType("datetime2");
        builder.Property(c => c.IdStatusProcessamento1).HasColumnName("IdStatusProcessamento_1");

        builder.Property(c => c.DataInicioProcessamento2).HasColumnName("DataProcessamento_2_Inicio").HasColumnType("datetime2");
        builder.Property(c => c.DataFimProcessamento2).HasColumnName("DataProcessamento_2_Fim").HasColumnType("datetime2");
        builder.Property(c => c.IdStatusProcessamento2).HasColumnName("IdStatusProcessamento_2");

        builder.Property(c => c.DataInicioProcessamento3).HasColumnName("DataProcessamento_3_Inicio").HasColumnType("datetime2");
        builder.Property(c => c.DataFimProcessamento3).HasColumnName("DataProcessamento_3_Fim").HasColumnType("datetime2");
        builder.Property(c => c.IdStatusProcessamento3).HasColumnName("IdStatusProcessamento_3");

        // Relacionamento com a tabela tbStatus
        builder
            .HasOne(s => s.StatusSolicitacao)
            .WithMany()
            .HasForeignKey(s => s.IdStatus)
            .IsRequired();

        // Relacionamentos com as tabelas tbSolicitacao para os processamentos
        builder
            .HasOne(s => s.StatusProcessamento1)
            .WithMany()
            .HasForeignKey(s => s.IdStatusProcessamento1)
        .IsRequired();

        builder
            .HasOne(s => s.StatusProcessamento2)
            .WithMany()
            .HasForeignKey(s => s.IdStatusProcessamento2)
        .IsRequired();

        builder
            .HasOne(s => s.StatusProcessamento3)
            .WithMany()
            .HasForeignKey(s => s.IdStatusProcessamento3)
            .IsRequired();

        //builder.HasOne(x => x.StatusSolicitacao)
        //    .WithMany()
        //    .HasForeignKey(x => x.IdStatus)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne(x => x.StatusSolicitacao)
        //    .WithMany()
        //    .HasForeignKey(x => x.IdStatusProcessamento1)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne(x => x.StatusSolicitacao)
        //    .WithMany()
        //    .HasForeignKey(x => x.IdStatusProcessamento2)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne(x => x.StatusSolicitacao)
        //    .WithMany()
        //    .HasForeignKey(x => x.IdStatusProcessamento3)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}