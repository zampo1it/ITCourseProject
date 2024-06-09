namespace ITProjectTryThree.Models.ViewModels
{
    public class DetailsViewModel
    {
        public string UserId { get; set; }
        public Collection ThisCollection { get; set; }
        public List<Item> Items { get; set; }
        public List<Comment> comments { get; set; }
        public string? userName { get; set; }
        public DetailsViewModel(Collection collection, List<Item> items, string userId)
        {
            ThisCollection = collection;
            Items = items;
            UserId = userId;
        }
    }
}
