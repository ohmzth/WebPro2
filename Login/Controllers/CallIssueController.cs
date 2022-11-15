using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class CallIssueController : Controller
    {
        // GET: CallIssueController
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CallIssueController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = 
                (sender, cert, charin, sslPolicyErros) => { return true; };
        }
        public ActionResult Index()
        {
            return View();
        }
            // GET: CallIssueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CallIssueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallIssueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CallIssueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CallIssueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CallIssueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CallIssueController/Delete/5
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
