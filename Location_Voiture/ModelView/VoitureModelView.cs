using Location_Voiture.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Location_Voiture.ModelView
{
    public class VoitureModelView
    {
        public int Id;
        [Required(ErrorMessage = "Matricule obligatoire")]
        [RegularExpression(@"([0-9]{5}[\.-/|][A-Z][\.-/|][0-9]{2})", ErrorMessage = "Respectez la forme suivante 00000/$/00")]
        public string Matricule { get; set; }
        [Required(ErrorMessage = "Nbr obligatoire")]
        [RegularExpression(@"(\d?)", ErrorMessage = "un Nombre")]
        public int Nbr_Porte { get; set; }
        public IFormFile Photo { get; set; }
        public string image { get; set; }
        [Required(ErrorMessage = "Couleur obligatoire")]
        public string Couleur { get; set; }
        public virtual Marque Marque { get; set; }
    }
}
