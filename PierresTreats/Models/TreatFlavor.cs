using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class TreatFlavor
  {
    public int TreatFlavorId { get; set; }
    public Treat Treat { get; set; }
    public Flavor Flavor { get; set; }
    public int TreatId { get; set; }
    public int FlavorId { get; set; }
  }
}