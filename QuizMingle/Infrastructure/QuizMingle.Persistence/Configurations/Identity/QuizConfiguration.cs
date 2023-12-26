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
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.TimeLimit).IsRequired();
            builder.Property(q => q.StartTime).IsRequired();

            // Questions relationship
            builder.HasMany(q => q.Questions)
                   .WithOne(qs => qs.Quiz)
                   .HasForeignKey(qs => qs.QuizId);

            //entity base common configuration
            builder.Property(e => e.CreatedByUserId).IsRequired();
            builder.Property(e => e.CreatedOn).IsRequired();
            builder.Property(e => e.ModifiedByUserId).IsRequired(false);
            builder.Property(e => e.ModifiedOn).IsRequired(false);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.DeletedByUserId).IsRequired(false);
            builder.Property(e => e.DeletedOn).IsRequired(false);

            builder.ToTable("Quizzes");
        }
    }
}