using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ITProjectTryThree.Models;
using ITProjectTryThree.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ITProjectTryThree.Controllers
{
    public class JiraTaskController : Controller
    {
        private readonly string _jiraBaseUrl = "https://itprojecttrythree202405100141003.atlassian.net";
        private readonly string _jiraApiToken = "ATATT3xFfGF0XFipZpu3DxnNWfDfJqho3jdrSzOAF_GDqpgHvKJ0PcTlj8MceVvmnZ5D9cXwkCT2aWcUctIlbJjVQc2eQBwpjRXKYCSKjjxHStUIO1LMq2LqkytQ2_e6hGRDvVelEYV8oBtypCkptNNJifo-uPymNogKqLvviDtbhcAvtPsgWOU=525E105E";
        private readonly string _jiraProjectKey = "ZNQQ";
        public string _returnUrl = "/";

        [HttpPost]
        public async Task<IActionResult> CreateTicket(JiraTask model)
        {
            var client = new HttpClient();
            var email = "zampo1it17@gmail.com";
            var emailAndToken = $"{email}:{_jiraApiToken}";
            string clientId = "";
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes(emailAndToken));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);
            var userCheckResponse = await client.GetAsync($"{_jiraBaseUrl}/rest/api/3/user/search?query={User.Identity.Name}");
            if (userCheckResponse.IsSuccessStatusCode)
            {
                // Проверяем содержимое ответа сервера
                // Create new user if not exists
                var newUser = new
                {
                    name = User.Identity.Name.Split('@')[0],
                    password = "123Ai@qwerty",
                    emailAddress = User.Identity.Name,
                    displayName = User.Identity.Name,
                    products = new[] { "jira-software" }
                };

                var newUserJson = JsonConvert.SerializeObject(newUser);
                var newUserContent = new StringContent(newUserJson, Encoding.UTF8, "application/json");

                var createUserResponse = await client.PostAsync($"{_jiraBaseUrl}/rest/api/3/user", newUserContent);

                if (createUserResponse.IsSuccessStatusCode)
                {
                    var rc = await createUserResponse.Content.ReadAsStringAsync();
                    var createdUser = JsonConvert.DeserializeObject<JObject>(rc);
                    clientId = createdUser.Value<string>("accountId");
                }
                else
                {
                    var errorContent = await createUserResponse.Content.ReadAsStringAsync();
                    return Content($"Error creating user: {errorContent}");
                }
            }

            var issueData = new
            {
                fields = new
                {
                    project = new { key = _jiraProjectKey },
                    summary = model.Summary,
                    reporter = new { id = clientId },
                    description = new
                    {
                        type = "doc",
                        version = 1,
                        content = new object[]
                        {
                new
                {
                    type = "paragraph",
                    content = new object[]
                    {
                        new
                        {
                            type = "text",
                            text = model.Description + " | "
                        },
                        new
                        {
                            type = "text",
                            text = "Click here",
                            marks = new object[]
                            {
                                new
                                {
                                    type = "link",
                                    attrs = new
                                    {
                                        href = "https://itprojecttrythree20240510141003.azurewebsites.net" + JiraTaskViewModel.returnURL
                                    }
                                }
                            }
                        },
                        new
                        {
                            type = "text",
                            text = " to see the page it was sent from."
                        }
                    }
                }
                        }
                    },
                    issuetype = new { name = "Task" },
                    priority = new { name = model.Priority }
                }
            };

            var json = JsonConvert.SerializeObject(issueData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_jiraBaseUrl}/rest/api/3/issue", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

            if (response.IsSuccessStatusCode)
            {
                var createdIssue = JsonConvert.DeserializeObject<JObject>(responseContent);
                var issueKey = createdIssue.Value<string>("key");
                var issueUrl = $"{_jiraBaseUrl}/browse/{issueKey}";
                UserPageViewModel.UserTickets.Add(createdIssue, User.Identity.Name);
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            JiraTaskViewModel.returnURL = returnUrl;
            return View();
        }
        public IActionResult Success()
        {
            JiraTaskViewModel viewModel = new JiraTaskViewModel
            {
                ticket = UserPageViewModel.UserTickets.Keys.Last(),
            };
            return View(viewModel);
        }
    }
}