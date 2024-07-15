using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebApp.Configurations
{
    public class TasksEntityConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Title).HasColumnName("title").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").IsRequired();
            builder.Property(p => p.IsCompleted).HasColumnName("isCompleted").IsRequired();
            builder.Property(p => p.Category).HasColumnName("category").IsRequired();
        }
    }
}
