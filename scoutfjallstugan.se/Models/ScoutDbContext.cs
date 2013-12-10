using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace scoutfjallstugan.se.Models
{
  public class ScoutDbContext : DbContext
  {
    public ScoutDbContext() : base("Name=ScoutDbContext")
    {
    }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Member> Members { get; set; } 
    public DbSet<Attend> Attendies { get; set; }
    public DbSet<Activity> Activities { get; set; }

   
  }
}