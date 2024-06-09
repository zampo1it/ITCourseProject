using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ITProjectTryThree.Models.ViewModels
{
    public class JiraTaskViewModel 
    {
        public JObject ticket { get; set; }
        static public string returnURL { get; set; }
    }
}
