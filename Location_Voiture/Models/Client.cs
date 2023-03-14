using System.Collections.Generic;

namespace Location_Voiture.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tele { get; set; }
        public string Cin { get; set; }
        public virtual ICollection<Location> Locations { get; set; }


    }
}
