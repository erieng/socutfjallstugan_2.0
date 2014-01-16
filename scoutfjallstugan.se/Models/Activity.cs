  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
  using System.Runtime.InteropServices.ComTypes;
  using System.Web;

namespace scoutfjallstugan.se.Models
{
  public class Activity
  {
    public Activity()
    {
      ActivityDateStartTime = "18:15";
      ActivityDateEndTime = "19:30";
    }

    public Guid Id { get; set; }

    [DisplayName("Aktivitet")]
    public string ActivityName { get; set; }

    [DisplayName("Startdatum")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime ActivityDateStart { get; set; }

    [DisplayName("Starttid")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:TT:mm}")]
    public string ActivityDateStartTime { get; set; }

    [DisplayName("Slutdatum")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime ActivityDateEnd { get; set; }

    [DisplayName("Sluttid")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:TT:mm}")]
    public string ActivityDateEndTime { get; set; }

    [DisplayName("Beskrivning")]
    public string Description { get; set; }

    [DisplayName("Endast för ledare")]
    public bool OnlyLeaders { get; set; }

    [DisplayName("Ansvarig")]
    public string Responsibility { get; set; }

    public virtual ICollection<Attend> Attendies { get; set; } 
  }


 

}