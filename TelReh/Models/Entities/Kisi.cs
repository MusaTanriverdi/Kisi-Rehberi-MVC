using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelReh.Models.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        public string Ad { get; set; }
        [DisplayName("Soyad")]
        public string Soyad { get; set; }
        [DisplayName("Ev Telefonu")]
        public string EvTelefon { get; set; }
        [DisplayName("Cep Telefonu")]
        public string CepTelefon { get; set; }
        [DisplayName("İş Telefonu")]
        public string IsTelefon { get; set; }
        [DisplayName("Email Adresi")]
        public string EmailAdres { get; set; }
        public string Adres { get; set; }
        [DisplayName("Şehir")]
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }

    }
}
