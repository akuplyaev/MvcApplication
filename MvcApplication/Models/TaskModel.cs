using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Task
    {
        public int GUID_Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Deadline { get; set; }
        public Task()
        {
        }
        public Task(int guid, string title, DateTime deadline)
        {
            GUID_Id = guid;
            Title = title;
            Deadline = deadline.ToShortDateString();
        }
    }
}