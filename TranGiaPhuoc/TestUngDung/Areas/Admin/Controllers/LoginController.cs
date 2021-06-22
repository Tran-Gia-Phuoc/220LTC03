using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.username, Common.EncryptorMD5(login.password));
                if(result == 1)
                {
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!! Hãy kiểm tra lại tài khoản và mật khẩu");
                }
            }
            return View("Index");
        }
    }
}
