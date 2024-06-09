using System.ComponentModel.DataAnnotations;

namespace ITProjectTryThree.Models.ViewModels
{
    public class DetailsItemViewModel
    {
        [Key]
        public int Id { get; set; }
        public Item item { get; set; }

        public Collection collection { get; set; }

        public List<Comment> comments { get; set; }

        public string? userName { get; set; }

        public string? userId { get; set; }

        public string? search { get; set; }

        public string? ImagePath { get; set; }

        public string? Tags { get; set; }
    }
}
