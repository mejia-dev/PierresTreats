using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "The flavor must be named.")]
    public string FlavorName { get; set; }
    public List<TreatFlavor> TreatTypes { get; }
  }
}