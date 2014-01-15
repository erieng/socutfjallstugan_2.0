  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace scoutfjallstugan.se.Models
{
  public class Activity
  {
    public Guid Id { get; set; }

    [DisplayName("Aktivitet")]
    public string ActivityName { get; set; }

    [DisplayName("Starttid")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime ActivityDateStart { get; set; }

    [DisplayName("Sluttid")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime ActivityDateEnd { get; set; }

    [DisplayName("Beskrivning")]
    public string Description { get; set; }

    [DisplayName("Endast för ledare")]
    public bool OnlyLeaders { get; set; }

    [DisplayName("Ansvarig")]
    public string Responsibility { get; set; }

    public virtual ICollection<Attend> Attendies { get; set; } 
  }


 

}