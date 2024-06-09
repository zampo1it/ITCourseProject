using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITProjectTryThree.Models
{
	public class Item
	{
		[Key]
		public int Id { get; set; }

		public int CollectionId { get; set; }

		public string Owner { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int IntCustom1 { get; set; }

		public int IntCustom2 { get; set; }

		public int IntCustom3 { get; set; }


		public string? StringCustom1 { get; set; }

		public string? StringCustom2 { get; set; }

		public string? StringCustom3 { get; set; }


		public bool BoolCustom1 { get; set; }

		public bool BoolCustom2 { get; set; }

		public bool BoolCustom3 { get; set; }


		public DateTime DateCustom1 { get; set; }

		public DateTime DateCustom2 { get; set; }

		public DateTime DateCustom3 { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string ImagePathString { get; set; }

		public string Tags { get; set; }

		public List<string> TagsList { get; set; }
	}
}
