using System;

namespace scoutfjallstugan.se.Models
{
  public class Member
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public string PatrolName { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Comment { get; set; }
    public bool IsLeader { get; set; }
  }

 
}

