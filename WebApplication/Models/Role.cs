using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApp.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            Role admin = new Role { Name = "admin" };
            Role user = new Role { Name = "user" };
            db.Roles.Add(admin);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Email = "somemail@gmail.com",
                Password = "123456",
                Role = admin
            });
            base.Seed(db);
        }
    }

}