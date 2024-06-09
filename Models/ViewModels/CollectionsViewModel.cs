
namespace ITProjectTryThree.Models.ViewModels
{
    public class CollectionsViewModel
    {

        public string Title { get; set; }

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
        public DateTime Date { get; set; } = DateTime.Now;

        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
    }
}
