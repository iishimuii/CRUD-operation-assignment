using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplicationForA4.Models;

namespace WebApplicationForA4.DatabaseContext
{
    public class AgentDbContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
    }
}