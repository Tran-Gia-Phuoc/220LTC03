using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private TranGiaPhuocContext db;

        public ProductDao()
        {
            db = new TranGiaPhuocContext();
        }

        public Product GetById(long id)
        {
            return db.Products.Find(id);
        }

        public int InsertProduct(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        /*        public string Insert(Product entityProduct)
                {
                    var product = Find(entityProduct.Name);
                    if (product == null)
                    {
                        db.Products.Add(entityProduct);
                    }
                    else
                    {
                        product.Name = entityProduct.Name;
                        if (!String.IsNullOrEmpty(entityProduct.Name))
                        {
                            product.Name = entityProduct.Name;
                        }
                    }
                    db.SaveChanges();
                    return entityProduct.Name;
                }
        */

        public bool Delete(string name)
        {
            try
            {
                var product = db.Products.Find(name);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product Find(string name)
        {
            return db.Products.Find(name);
        }


        public IEnumerable<Product> ListAll(int page, int pageSize)
        {
            return db.Products.OrderBy(x => x.Quantily).ThenByDescending(y => y.UnitCost).ToPagedList(page, pageSize);
        }


        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }

        public Product FindPro(int? id)
        {
            return db.Products.Find(id);
        }
    }
}
