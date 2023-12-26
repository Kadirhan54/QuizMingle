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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.CorrectAnswer).IsRequired();
            builder.Property(x => x.OptionA).IsRequired();
            builder.Property(x => x.OptionB).IsRequired();
            builder.Property(x => x.OptionC).IsRequired();
            builder.Property(x => x.OptionD).IsRequired();

            // Quiz relationship
            builder.HasOne(x => x.Quiz)
                   .WithMany(x => x.Questions)
                   .HasForeignKey(x => x.QuizId);

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