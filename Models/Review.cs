// Review model
using dotnetapp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
 
        [Range(1, 5)]
        public int Rating { get; set; }
 
        public DateTime DateCreated { get; set; }
 
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}

