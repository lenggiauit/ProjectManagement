using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SubFolder { get; set; }
        public string MailSender { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string MailSignature { get; set; }
        public string MailDefaultSubject { get; set; }
        public string MailDefaultContent { get; set; }
        public string GoogleapisUrl { get; set; } 
        public string MailForgotPasswordSubject { get; set; }
        public string MailForgotPasswordContent { get; set; } 
        public string ForgotPasswordUrl { get; set; }
        public string ClientErrorMappingUrl { get; set; }


    }
}
