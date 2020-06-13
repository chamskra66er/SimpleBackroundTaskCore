using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Models
{
    public class Domains
    {
        public int Id { get; set; }
        public string ServerName{get; set;}
        public bool Status { get; set; }
        public string Url { get; set; }
    }
}
