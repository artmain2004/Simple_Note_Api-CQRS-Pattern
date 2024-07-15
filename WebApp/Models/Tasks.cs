using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Tasks
    {
        public Guid Id { get; set; }

        public  string Title { get; set; }

        public  string Description { get; set; }

        public string Category { get; set; }

        public bool IsCompleted { get; set; }


        public Tasks(string title, string description,string category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            IsCompleted = false;
            Category = category;
        }
    }
}
