﻿using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }  
        [Required] 
        public string Role { get; set; }  
    }
}

