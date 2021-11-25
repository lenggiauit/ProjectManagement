using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Todo = new HashSet<Todo>();
            UserOnProject = new HashSet<UserOnProject>();
            UserOnTeam = new HashSet<UserOnTeam>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public Guid? RoleId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Todo> Todo { get; set; }
        public virtual ICollection<UserOnProject> UserOnProject { get; set; }
        public virtual ICollection<UserOnTeam> UserOnTeam { get; set; }
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<Team> Teams { get; set; }
    }
}
