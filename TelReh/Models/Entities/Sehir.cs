using System.ComponentModel.DataAnnotations.Schema;

namespace TelReh.Models.Entities
{
    [Table("Şehirler")]
    public class Sehir
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
        public int PlakaKodu { get; set; }

    }
}
