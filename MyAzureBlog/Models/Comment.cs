using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

// Comment nesnesi oluşturuluyor, 15.01.2015 ypala
namespace MyAzureBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        public DateTime Date { get; set; }
        public bool Published { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public virtual Entry Entry { get; set; }
    }
}