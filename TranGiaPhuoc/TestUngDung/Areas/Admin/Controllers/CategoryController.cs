using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
         public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }



        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListWhereAll(searchString, page, pagesize);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }


        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}


        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new CategoryDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var ten = model.Name;
                model.Name = ten;
                string result;
                // Tìm tên đăng nhập có trùng không
                //Nếu  trùng thì trả về trang Create

                result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo danh mục không thành công");
                }
            }
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }


        [HttpDelete]
        public ActionResult Delete(string name)
        {
            var dao = new CategoryDao().Delete(name);
            return RedirectToAction("Index");
        }
    }
}