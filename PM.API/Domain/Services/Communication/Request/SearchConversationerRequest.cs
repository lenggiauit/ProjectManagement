﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Request
{
    public class SearchConversationerRequest
    {
        [Required]
        public string Keyword { get; set; }
    }
}