using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios", "dbo");

            builder.HasKey(u => u.Id)
                .HasName("PK_Usuarios");

            builder.Property(u => u.Id)
                .IsRequired()
                .HasColumnName("ID_Usuario")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnName("Nombre")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.Property(u => u.Identification)
                .IsRequired()
                .HasColumnName("Identificacion")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Correo")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnName("Contraseña")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnName("Fecha_Creacion")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
                .IsRequired()
                .HasColumnName("Fecha_Actualizacion")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(row => row.Status)
                .IsRequired()
                .HasColumnName("Estado")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Usuarios_Correo");

            builder.HasMany(u => u.UserComics)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);
        }
    }
}
