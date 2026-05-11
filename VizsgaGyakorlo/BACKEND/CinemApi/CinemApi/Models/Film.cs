using System.ComponentModel.DataAnnotations;

namespace CinemApi.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Ev { get; set; }
        public int RendezoId { get; set; }
        public Rendezo Rendezo { get; set; }

        public ICollection<Vetites> Vetitess { get; set; }

    }
}
