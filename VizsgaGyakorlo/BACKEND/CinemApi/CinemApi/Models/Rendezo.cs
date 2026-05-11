using System.ComponentModel.DataAnnotations;

namespace CinemApi.Models
{
    public class Rendezo
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Nemzetiseg { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
