
using Newtonsoft.Json.Linq;

namespace ITProjectTryThree.Models.ViewModels
{
    public class UserPageViewModel
    {
        public static Dictionary<JObject, string> UserTickets = new Dictionary<JObject, string>();

        public string UserName { get; set; }
        public IEnumerable<Collection> Collections { get; set; }
    }
}
