using System;
using dotnetapp.Data;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string Role { get; set; }
    }
}