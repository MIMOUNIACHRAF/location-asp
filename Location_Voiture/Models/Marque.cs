using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Location_Voiture.Models
{
    public class Marque
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Libelle Obligatoire")]
        public string Libelle { get; set; }
        public virtual ICollection<Voiture> Voitures { get; set; }
    }
}
