using System.ComponentModel.DataAnnotations;

namespace CinemApi.Models
{
    public class Vetites
    {
        [Key]
        public int Id { get; set; }
        public int Terem { get; set; }
        public int JegyAr { get; set; }
        public DateTime Idopont { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }
}
