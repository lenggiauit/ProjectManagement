﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities.Update
{
    public partial class Project
    {
        public Project()
        {
            Todo = new HashSet<Todo>();
            UserOnProject = new HashSet<UserOnProject>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsArchived { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ProjectStatus Status { get; set; }
        public virtual ICollection<Todo> Todo { get; set; }
        public virtual ICollection<UserOnProject> UserOnProject { get; set; }
    }
}