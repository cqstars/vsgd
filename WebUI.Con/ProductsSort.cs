using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Helper;

namespace WebUI.Con
{
    public class ProductsSortController:Controller
    {
        public ViewResult Index(int id)
        {

            ViewBag.Title = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy_NoTrack(t => t.ProductsSortID == id).FirstOrDefault().ProductsSortName;
            var list = OperateContext.Current.BLLSession.IGoodsSortBLL.GetListBy(s => s.ProductsSortID == id).Select(t => new Model.ViewModel.GoodSort()
            {
                GoodsSortName = t.GoodsSortName,
                GoodsSortID = t.GoodsSortId,
                nodes = t.Goods.Select(m => new Model.ViewModel.Good() { 
                GoodsID=m.GoodsID,
                GoodsName=m.GoodsName
                }).ToList()
            }).ToList();
            
            return View(list);
            
        }
       
        #region 1.0--展示产品信息 GoodsListShow(string GoodsID)
        
        public ActionResult GoodsListShow(int id)
        {
            //if (GoodsID == null || GoodsID == 0)
            //{
            //    GoodsID = 1;
            //}

            var GoodsList = OperateContext.Current.BLLSession.IGoodBLL.GetListBy_NoTrack(s => s.GoodsID == id).Select(s => new Model.ViewModel.GoodsList()
            {
                GoodsID = s.GoodsID,
                GoodsName = s.GoodsName,
                GoodsPic = s.GoodsPic,
                ProductsSortID = s.ProductsSortID ?? 0,
                GoodsSortID = s.GoodsSortID ?? 0,
                RentPrice = (s.RentPrice ?? 0).ToString("#0.00"),
                SalePrice = (s.SalePrice ?? 0).ToString("#0.00"),
                GoodsBrife = s.GoodsBrife,
                Specifications = s.Specifications,
                Features = s.Features,
                Supplies = s.Supplies

            }).FirstOrDefault();

           
            return PartialView(GoodsList);


        }
        #endregion
        
        #region 2.0--展示产品信息 GoodlistShowList_Direct(string GoodsID)

        public ActionResult GoodlistShowList_Direct(int id)
        {
            //if (GoodsID == null || GoodsID == 0)
            //{
            //    GoodsID = 1;
            //}

            var GoodsList = OperateContext.Current.BLLSession.IGoodBLL.GetListBy_NoTrack(s => s.GoodsID == id).Select(s => new Model.ViewModel.GoodsList()
            {
                GoodsID = s.GoodsID,
                GoodsName = s.GoodsName,
                GoodsPic = s.GoodsPic,
                ProductsSortID = s.ProductsSortID ?? 0,
                GoodsSortID = s.GoodsSortID ?? 0,
                RentPrice = (s.RentPrice ?? 0).ToString("#0.00"),
                SalePrice = (s.SalePrice ?? 0).ToString("#0.00"),
                GoodsBrife = s.GoodsBrife,
                Specifications = s.Specifications,
                Features = s.Features,
                Supplies = s.Supplies

            }).FirstOrDefault();
            ViewBag.Title = GoodsList.GoodsName;

            return View(GoodsList);


        }
        #endregion
    }
}
