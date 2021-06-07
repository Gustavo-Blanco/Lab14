using System;

namespace Lab14.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Authenticated { get; set; }
    }
}