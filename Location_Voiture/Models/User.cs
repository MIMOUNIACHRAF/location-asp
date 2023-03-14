using System;

namespace Location_Voiture.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public DateTime Date_inscription { get; set; }
        public DateTime date_connction { get; set; }
    }
}
