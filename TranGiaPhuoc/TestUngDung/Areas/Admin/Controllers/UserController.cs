using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpDelete]
        public ActionResult Delete(string username)
        {
            new UserDao().Delete(username);
            return RedirectToAction("Index");
        }
    }
}
