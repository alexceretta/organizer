using Microsoft.EntityFrameworkCore;
using organizer_web.Builders;

namespace organizer_web.Models
{

    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ToDoConfiguration());
        }
    }

}