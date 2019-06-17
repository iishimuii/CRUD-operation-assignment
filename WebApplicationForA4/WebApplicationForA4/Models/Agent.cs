using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationForA4.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string MakeupPlan { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
    }
}