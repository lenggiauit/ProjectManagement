using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Request
{
    public class CreateConversationRequest
    {
        [Required]
        public Guid[] Users { get; set; } 
        public string Title { get; set; }
    }
}
