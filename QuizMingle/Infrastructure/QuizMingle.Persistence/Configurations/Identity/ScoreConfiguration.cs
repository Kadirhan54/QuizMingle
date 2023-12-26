using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Persistence.Configurations.Identity
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.ScoreValue).IsRequired();
            builder.Property(s => s.DateTaken).IsRequired();

            // User relationship
            builder.HasOne(s => s.User)
                   .WithMany()
                   .HasForeignKey(s => s.UserId);

            // Quiz relationship
            builder.HasOne(s => s.Quiz)
                   .WithMany()
                   .HasForeignKey(s => s.QuizId);

            //entity base common configuration
            builder.Property(e => e.CreatedByUserId).IsRequired();
            builder.Property(e => e.CreatedOn).IsRequired();
            builder.Property(e => e.ModifiedByUserId).IsRequired(false);
            builder.Property(e => e.ModifiedOn).IsRequired(false);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.DeletedByUserId).IsRequired(false);
            builder.Property(e => e.DeletedOn).IsRequired(false);
        }
    }
}