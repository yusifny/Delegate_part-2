using System;
using IEntity_interface.Interface;
using Utils.Enum;

namespace IEntity_interface.Models
{
    public class User : IEntity
	{
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public int Id { get; }
        private static int _id;
        public void Showinfo()
        {
            Console.WriteLine($"Username: {Username} \nEmail: {Email}");
        }
        public User(string username, string email, Role role)
        {
            _id++;
            Id = _id;
            Username = username;
            Email = email;
            Role = role;
        }
    }
}

