using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAzureBlog.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Index]
        [MaxLength(80)]
        public string Title { get; set; }

        [MaxLength(80)]
        public string SeoUrl { get; set; }

        [MaxLength(150)]
        public string Keywords { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public bool Published { get; set; }


        public Category Category { get; set; }
    }
}