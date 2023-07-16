using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelReh.Models.Entities
{
    [Table("Loginler")]
    public class Login
    {
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre")]
        public string Sifre { get; set; }
    }
}
