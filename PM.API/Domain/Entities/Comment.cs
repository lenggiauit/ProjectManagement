using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class Comment
    {
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }
        [Column("Comment")]
        public string Comment1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public Guid? CreateBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
