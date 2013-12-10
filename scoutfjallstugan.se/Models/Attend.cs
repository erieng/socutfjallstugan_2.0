using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace scoutfjallstugan.se.Models
{
  public class Attend
  {
    public int AttendId { get; set; }

    [Key][Column(Order = 0)]
    [ForeignKey("Member")]
    public Guid MemberId { get; set; }
    
    [Key][Column(Order = 1)]
    [ForeignKey("Activity")]
    public Guid ActivityId { get; set; }
    public bool Extra { get; set; }


    public virtual Member Member { get; set; }
    public virtual Activity Activity { get; set; }
  }

  
}