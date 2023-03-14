using System;
namespace Location_Voiture.Models
{
    public class Assurance
    {
        public int Id { get; set; }
        public string Agence { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int Prix { get; set; }
        public virtual Voiture Voiture { get; set; }

    }
}
