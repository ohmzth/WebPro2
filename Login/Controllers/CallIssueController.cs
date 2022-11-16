using Login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace Login.Controllers
{
    public class CallissueController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CallissueController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback =
               (sender, cert, chain, SslPolicyErrors) => { return true; };
        }
        // GET: Callissue
        public async Task<ActionResult> Index()
        {
            var issue = await GetIssues();
            return View(issue);
        }

        [HttpGet]
        public async Task<List<Issue>> GetIssues()
        {
            List<Issue> issueList = new List<Issue>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7084/api/Issue"))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    issueList = JsonConvert.DeserializeObject<List<Issue>>(strJson);
                }
            }
            return issueList;
        }
        public async Task<ActionResult> Details(int id)
        {
            Issue issue = new Issue();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7084/api/Issue/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    issue = JsonConvert.DeserializeObject<Issue>(strJson);
                }
            }
            return View(issue);
        }
        public async Task<ActionResult> search(int id)
        {
            Issue issue = new Issue();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7084/api/Issue/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    issue = JsonConvert.DeserializeObject<Issue>(strJson);
                }
            }
            return View(issue);
        }



        // GET: Callissue/Create


        public ActionResult Create()
        {
            return View();
        }

        // POST: Callissue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Issue issue)
        {
            try
            {
                Issue sue = new Issue();
                using (var httpClient = new HttpClient(_clientHandler))
                {
                    StringContent content =
                        new StringContent(JsonConvert.SerializeObject(issue), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7084/api/Issue", content))
                    {
                        string strJson = await response.Content.ReadAsStringAsync();
                        sue = JsonConvert.DeserializeObject<Issue>(strJson);
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }

                return View(sue);
            }
            catch
            {
                return View();
            }

        }

        // GET: Callissue/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Issue issue = new Issue();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7084/api/Issue/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    issue = JsonConvert.DeserializeObject<Issue>(strJson);
                }
            }
            return View(issue);
        }

        // POST: Callissue/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Issue issue)
        {

            Issue sue = new Issue();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content =
                        new StringContent(JsonConvert.SerializeObject(issue), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7084/api/Issue/" + id, content))
                {

                }
            }
            return RedirectToAction(nameof(Index));
        }

       

        // GET: Callissue/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            string del = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:7084/api/Issue/" + id))
                {
                    del = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));

        }
        // POST: Callissue/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
