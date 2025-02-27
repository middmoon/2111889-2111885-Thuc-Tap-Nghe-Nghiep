using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace server.Models
{
  public class Test
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}