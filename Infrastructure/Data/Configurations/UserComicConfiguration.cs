using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class UserComicConfiguration : IEntityTypeConfiguration<UserComic>
    {
        public void Configure(EntityTypeBuilder<UserComic> builder)
        {
            builder.ToTable("UserComics");

            builder.HasKey(uc => new { uc.UserId, uc.ComicId })
                .HasName("PK_UserComic");

            builder.Property(uc => uc.UserId)
                .HasColumnName("ID_Usuario")
                .HasColumnType("int");

            builder.Property(uc => uc.ComicId)
                .HasColumnName("ID_Comic")
                .HasColumnType("int");

            builder.HasOne(uc => uc.User)
                .WithMany(u => u.UserComics)
                .HasForeignKey(uc => uc.UserId);

            
        }
    }
}

