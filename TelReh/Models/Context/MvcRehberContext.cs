using System.Data.Entity;
using TelReh.Models.Entities;

namespace TelReh.Models.Context
{
    public class MvcRehberContext:DbContext
    {
        public MvcRehberContext() : base("Server=.;Database=MvcRehberDB;Trusted_Connection=true")
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Login> Loginler { get; set; }
    }
}
