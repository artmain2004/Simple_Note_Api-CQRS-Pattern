
using WebApp.Configurations;

using Microsoft.EntityFrameworkCore;
using WebApp.Models;


namespace WebApp.Data
{
    public class TaskManagerDbContext : DbContext
    { 
        public DbSet<Tasks> Tasks { get; set; }



        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TasksEntityConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
