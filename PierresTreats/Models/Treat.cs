using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "The treat must be named.")]
    public string TreatName { get; set; }
    public List<TreatFlavor> FlavorTypes { get; }
  }
}
