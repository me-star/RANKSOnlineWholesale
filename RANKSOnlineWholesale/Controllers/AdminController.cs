using Newtonsoft.Json;
using RANKSOnlineWholesale.DBase;
using RANKSOnlineWholesale.Models;
using RANKSOnlineWholesale.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RANKSOnlineWholesale.Controllers
{
    public class AdminController : Controller
    {
        

        // GET: Admin

        public BaseUnitOfWork _unitOfWork = new BaseUnitOfWork();

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult Dashboard()

        {
            return View();
        }
        public ActionResult Categories()
        {
            List<Category> allcategories = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory", cd);

        }
            
            
            public ActionResult Product()
            {
                return View(_unitOfWork.GetRepositoryInstance<Product>().GetProduct());
            }

            public ActionResult ProductEdit(int productId)
            {
                return View(_unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId));
            }
        [HttpPost]
        public ActionResult ProductEdit(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImages/"), pic);

                //file is upload
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            _unitOfWork.GetRepositoryInstance<Product>().Update(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult ProductAdd()
            {
            ViewBag.CategoryList = GetCategory();
                 return View();
            }
        [HttpPost]
        public ActionResult ProductAdd(Product tbl,HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImages/"), pic);

                //file is upload
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;            
            _unitOfWork.GetRepositoryInstance<Product>().Add(tbl);
            return RedirectToAction("Product");
        }

    }

    }


     
       
