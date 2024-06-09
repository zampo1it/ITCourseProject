using Microsoft.AspNetCore.Identity;

namespace ITProjectTryThree.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<IdentityUser> Users { get; set; }
        public List<string> Roles { get; set; }
    }
}
