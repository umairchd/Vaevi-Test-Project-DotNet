using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vaevi.Interfaces.IServices;
using Vaevi.Models.WebModels;
using Vaevi.Web.Extensions;

namespace Vaevi.Web.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }
        // GET: ContactsController
        public async Task<ActionResult> Index()
        {
            var list = await _service.GetAll(User.GetUserId());
            return View(list);
        }

        // GET: ContactsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _service.FindAsync(User.GetUserId(), id);
            return View(response);
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactModel model)
        {
            model.UserId = User.GetUserId();
            await _service.SaveOrUpdate(model);
            return RedirectToAction("Index");
        }

        // GET: ContactsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _service.FindAsync(User.GetUserId(), id);
            return View(response);
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ContactModel model)
        {
            try
            {
                await _service.SaveOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.FindAsync(User.GetUserId(), id);
            return View(response);
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ContactModel model)
        {
            try
            {
                await _service.Delete(User.GetUserId(), id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
