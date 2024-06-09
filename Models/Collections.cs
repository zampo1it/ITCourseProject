using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITProjectTryThree.Models
{
    public class Collection
    {
        [Key]
        public int id { get; set; }

        public string Owner { get; set; }

        public string Title { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }

		[Required(AllowEmptyStrings = true)]
		public string ImagePathString { get; set; }

		public CollectionType Type { get; set; }

        public string Description { get; set; }

        public string? IntName1 { get; set; }
        public string? IntName2 { get; set; }
        public string? IntName3 { get; set; }

        public string? StringName1 { get; set; }
        public string? StringName2 { get; set; }
        public string? StringName3 { get; set; }

        public string? BoolName1 { get; set; }
        public string? BoolName2 { get; set; }
        public string? BoolName3 { get; set; }
        public DateTime Date { get; set; }
    }
}
