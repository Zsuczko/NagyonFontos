using System.ComponentModel.DataAnnotations;

namespace TuraRandi.Models
{
	//Az osztály szerkezete: Testimonial(Id, Name, Age, Location, TestimonialText, ImageUrl)

	public class Testimonial {

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string? Location { get; set; }
		public string TestimonialText { get; set; }
		public string? ImageUrl { get; set; }
	}




}
