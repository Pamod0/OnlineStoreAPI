﻿namespace PokemonReviewApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // e.g., "Customer", "Admin"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}