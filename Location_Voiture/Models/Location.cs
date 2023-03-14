using System;

namespace Location_Voiture.Models
{
    public class Location
    {
        public int Id { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public bool Retour { get; set; }
        public int Prix_Jour { get; set; }
        public virtual Voiture Voiture { get; set; }
        public virtual Client Client { get; set; }


    }
}
