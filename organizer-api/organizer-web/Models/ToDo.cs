using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_web.Models
{
    public class ToDo : BaseEntity
    {
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Completed { get; set; }
    }

}