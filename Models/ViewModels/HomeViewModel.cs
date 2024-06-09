
namespace ITProjectTryThree.Models.ViewModels
{
    public class HomeViewModel
    {
        public string UserId { get; set; }

        public List<Item> Items { get; set; }
        public string Lang { get; set; }
        public List<Collection> Collections { get; set; }

    }
}
