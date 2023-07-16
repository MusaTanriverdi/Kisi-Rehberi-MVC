using System.ComponentModel;

namespace TelReh.Models.KisiModel
{
    public class LoginVM
    {
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre")]
        public string Sifre { get; set; }
    }
}
