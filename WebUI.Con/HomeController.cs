using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Helper;



namespace WebUI.Con
{
    public class HomeController:Controller
        
    {
        public ViewResult Index()
        {

            
            return View();
            
        }
        public ActionResult ProductsLink()
        {
            var list = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy(s => s.ProductsSortID > 0).Select(t => new Model.ViewModel.ProductsSort()
            {
                ProductsSortName = t.ProductsSortName,
                ProductsSortID = t.ProductsSortID
            }).ToList();
            return PartialView(list);
        }
        #region 1.0--查询产品显示控制器
        public ViewResult InqueryRult()
        {
            string k = Request["InqueryKeyWord"].ToString();

            var InqueryRult = OperateContext.Current.BLLSession.IGoodBLL.GetListBy_NoTrack(s => s.GoodsBrife.Contains(k)).Select(t=>new Model.ViewModel.InqueryRult(){
            GoodsName=t.GoodsName,
            GoodsID=t.GoodsID,
            GoodsBrife=t.GoodsBrife.Substring(0,100)+"......",
            keywords=k
            }).ToList();
            ViewBag.Title = k;
            return View(InqueryRult);

        } 
        #endregion
        #region 2.0--公司简介页面
        public ViewResult CompanyBrife()
        {


            return View();

        } 
        #endregion
        #region 3.0--服务与支持
        public ViewResult Service()
        {


            return View();

        }
        #endregion
        #region 4.0--招聘
        public ViewResult Wanted()
        {


            return View();

        }
        #endregion
    }
}
