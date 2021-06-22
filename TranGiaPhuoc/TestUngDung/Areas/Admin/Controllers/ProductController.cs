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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListAll(page, pagesize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new ProductDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product Pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                int id = dao.InsertProduct(Pro);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Product");
                }
                else 
                {
                    ModelState.AddModelError("", "Thêm Thất Bại");
                }
            }
            return View("Create");
        }
        
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDao();
            var product = dao.GetById(id);
            SetViewBag(product.ID_category);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                
            }
            SetViewBag(model.ID_category);
            return View();
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.ID_category = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(string name)
        {
            var dao = new ProductDao().Delete(name);
            return RedirectToAction("Index");
        }
        
        public ActionResult Chitiet(int id)
        {
            var ct = new ProductDao().FindPro(id);
            return View(ct);
        }
    }
}
