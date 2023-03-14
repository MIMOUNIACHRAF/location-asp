using System.ComponentModel.DataAnnotations;

namespace Location_Voiture.ModelView
{
    public class UserRegisterModelView
    {
        [Required(ErrorMessage ="Entrez un Nom")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Entrez un Prenom")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Entrez un Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Entrez un PassWord")]
        [MinLength(6,ErrorMessage = "PassWord > 6")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Entrez un PassWord")]
        [Compare("PassWord", ErrorMessage = "PassWordComfirm est different")]
        [DataType(DataType.Password)]
        public string ComfirmPassWord { get; set; }
    }
}
