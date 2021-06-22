using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private TranGiaPhuocContext db;

        public CategoryDao()
        {
            db = new TranGiaPhuocContext();
        }

        public string Insert(Category entityCategory)
        {
            var category = Find(entityCategory.Name);
            if (category == null)
            {
                db.Categories.Add(entityCategory);
            }
            else
            {
                category.Name = entityCategory.Name;
                if (!String.IsNullOrEmpty(entityCategory.Name))
                {
                    category.Name = entityCategory.Name;
                }
            }
            db.SaveChanges();
            return entityCategory.Name;
        }

        public bool Delete(string name)
        {
            try
            {
                var category = db.Categories.Find(name);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public Category Find(string name)
        {

            return db.Categories.Find(name);
        }


        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }


        public IEnumerable<Category> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }

    }
}

