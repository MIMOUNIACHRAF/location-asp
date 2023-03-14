using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Location_Voiture.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public int Nbr_Porte { get; set; }
        public string Photo { get; set; }
        
        public string Couleur { get; set; }
        public virtual Marque Marque { get; set; }
        public virtual ICollection<Assurance> Assurances { get; set; }
        public virtual ICollection<Location> Locations { get; set; }

    }
}
