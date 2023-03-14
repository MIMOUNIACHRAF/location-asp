using System.ComponentModel.DataAnnotations;

namespace Location_Voiture.ModelView
{
    public class UserLoginModelView
    {
        [Required(ErrorMessage = "Entrez un Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Entrez un PassWord")]
        [MinLength(6, ErrorMessage = "PassWord > 6")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
