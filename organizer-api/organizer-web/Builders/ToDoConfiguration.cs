using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using organizer_web.Models;
using System;

namespace organizer_web.Builders
{

    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).IsRequired();

            builder.HasData
            (
                new ToDo { Id = new Guid("9a6dece5-fb51-4e42-a135-cb3c31d071ba"), CreationDate = DateTime.Now, Description = "Test To-Do application", Completed = false }
            );
        }
    }

}