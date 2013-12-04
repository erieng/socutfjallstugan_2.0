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
    [Key][Column(Order = 0)]
    public Guid MemberId { get; set; }
    [Key][Column(Order = 1)]
    public Guid ActivityId { get; set; }
    public bool Extra { get; set; }
  }

  
}