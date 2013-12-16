using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scoutfjallstugan.se.Models
{
  public class AttendActivityModel
  {
    public int ActivityId { get; set; }
    public string MemberName { get; set; }
    public bool Extra { get; set; }
    public bool Attends { get; set; }
    
  }
}