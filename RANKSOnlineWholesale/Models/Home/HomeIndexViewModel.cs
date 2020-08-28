using PagedList;
using RANKSOnlineWholesale.DBase;
using RANKSOnlineWholesale.Repository;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace RANKSOnlineWholesale.Models.Home
{
    public class HomeIndexViewModel
    {

        public BaseUnitOfWork _unitOfWord = new BaseUnitOfWork();
        RANKSWHOLESALEEntities context = new RANKSWHOLESALEEntities();
        public IPagedList<Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search,int pageSize,int? page)
        {
            SqlParameter[] param = new SqlParameter[] {
                   new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Product> data = context.Database.SqlQuery<Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, 3);
            return new HomeIndexViewModel
            {

                ListOfProducts = data
                
            };
            

        }
      
    };
}
    
