using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace restapi.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("id")]
        public int id { get; set; }
        [Column("slur")]
        [StringLength(45, MinimumLength=3, ErrorMessage = "Line author name has unwanted lenght",ErrorMessageResourceType = typeof(BadRequestResult))]
        public string slur { get; set; }
        [Column("body")]
        [Required(ErrorMessage ="Content gets error" )]
        public string body { get; set; }
    }
}