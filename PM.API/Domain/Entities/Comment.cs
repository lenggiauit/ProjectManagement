using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Comment
    {
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Comment1 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
