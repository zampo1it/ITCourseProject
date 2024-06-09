namespace ITProjectTryThree.Models.ViewModels
{
    public class CreateItemViewModel
    {
        public Item ThisItem { get; set; }
        public Collection? ThisCollection { get; set; }
        public CreateItemViewModel(Collection collection, Item item)
        {
            ThisItem = item;
            ThisCollection = collection;
        }

        public CreateItemViewModel()
        {
        }
    }
}
