using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Dynamic;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace scoutfjallstugan.se.Models
{
  public class Member
  {
   
    public Guid Id { get; set; }

    [DisplayName("Förnamn")]
    public string FirstName { get; set; }
    
    [DisplayName("Efternamn")]
    public string LastName { get; set; }

    [DisplayName("Namn")]
    public string Name
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }

    [DisplayName("Födelsedatum")]
    [DisplayFormat(DataFormatString = "{0:YYMMdd}")]
    public string BirthDate { get; set; }

    [DisplayName("Patrull")]
    public string PatrolName { get; set; }

    [DisplayName("Gatuadress")]
    public string StreetAddress { get; set; }

    [DisplayName("Postnummer")]
    public string ZipCode { get; set; }

    [DisplayName("Stad")]
    public string City { get; set; }

    [DisplayName("Telefon")]
    public string Phone { get; set; }

    [DisplayName("Mobil")]
    public string Mobile { get; set; }

    [DisplayName("E-post")]
    public string Email { get; set; }

    [DisplayName("Kommentar")]
    public string Comment { get; set; }

    [DisplayName("Är ledare")]
    public bool IsLeader { get; set; }

    [DisplayName("Ej aktiv")]
    public bool IsInactive { get; set; }

    public virtual ICollection<Attend> Attendies { get; set; } 
  }

 
}

