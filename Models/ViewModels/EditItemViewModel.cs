using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITProjectTryThree.Models.ViewModels
{
    public class EditItemViewModel
    {
        [Key]
        public int ItemId { get; set; }

        public Item ThisItem { get; set; }

        public Collection? ThisCollection { get; set; }

        public EditItemViewModel(Collection collection, Item item, int itemId)
        {
            ThisItem = item;
            ThisCollection = collection;
            ItemId = itemId;
        }

        public EditItemViewModel()
        {
        }
    }
}
