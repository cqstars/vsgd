using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebUI.Helper;
using System.Web;

namespace WebUI.Con.Admin
{
    public class AdminProductController : Controller
    {


        public ActionResult ProductsSortSetup()
        {
            return PartialView();
        }
        #region 增加产品一级分类，即ProductsSort表

        public ActionResult ProductsSortAdd(Model.ViewModel.AdminProductsSortAdd P)
        {
            Model.ProductsSort Add_p = new Model.ProductsSort();
            Add_p.ProductsSortName = P.ProductsSortName;
            int ok = OperateContext.Current.BLLSession.IProductsSortBLL.Add(Add_p);
            if (ok == 1)
            {
                return Content("ok");
            }
            else
            {
                return Content("error");
            }

            // return PartialView("ProductsSortSetup");
        } 
        #endregion
        #region 添加产品二级分类，即GoodsSort表

        public ActionResult GoodsSortAdd()
        {

            if (Request["GoodsSortName"] != null && Request["GoodsSortName"].ToString() != "")
            {
                Model.GoodsSort add = new Model.GoodsSort();
                add.ProductsSortID = Convert.ToInt32(Request["ProductsSortID"]);
                add.GoodsSortName = Request["GoodsSortName"].ToString();
                int ok = OperateContext.Current.BLLSession.IGoodsSortBLL.Add(add);
                if (ok == 1)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("error");
                }
            }
            else { return Content("error"); }

        } 
        #endregion
        #region 产品分类展示
        [Common.Attributes.Skip]
        public ActionResult ProductsSortList()
        {


            var ProductsSortList = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy_NoTrack(s => s.ProductsSortID > 0).Select(s => new Model.ViewModel.ProductsSort()
            {
                ProductsSortName = s.ProductsSortName,
                ProductsSortID = s.ProductsSortID,
                nodes = s.GoodsSorts.Select(t => new Model.ViewModel.GoodSort() { GoodsSortID = t.GoodsSortId, GoodsSortName = t.GoodsSortName }).ToList()
            }).ToList();
            return PartialView(ProductsSortList);
            // return PartialView("ProductsSortSetup");
        } 
        #endregion
        #region 产品目录树
        [Common.Attributes.Skip]
        public ActionResult ProductsSortTree()
        {


            var ProductsSortList = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy_NoTrack(s => s.ProductsSortID > 0).Select(s => new Model.ViewModel.ProductsSort()
            {
                ProductsSortName = s.ProductsSortName,
                ProductsSortID = s.ProductsSortID,
                nodes = s.GoodsSorts.Select(t => new Model.ViewModel.GoodSort()
                {
                    GoodsSortID = t.GoodsSortId,
                    GoodsSortName = t.GoodsSortName,
                    nodes = t.Goods.Select(
                        u => new Model.ViewModel.Good()
                        {
                            GoodsID = u.GoodsID,
                            GoodsName = u.GoodsName
                        }).ToList()
                }).ToList()
            }).ToList();
            return PartialView(ProductsSortList);
            // return PartialView("ProductsSortSetup");
        } 
        #endregion
        #region 下拉框数据
        [Common.Attributes.Skip]
        public ActionResult ProductsSortDrop()
        {


            var ProductsSortList = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy_NoTrack(s => s.ProductsSortID > 0).Select(s => new Model.ViewModel.ProductsSort()
            {
                ProductsSortName = s.ProductsSortName,
                ProductsSortID = s.ProductsSortID,
                nodes = s.GoodsSorts.Select(t => new Model.ViewModel.GoodSort()
                {
                    GoodsSortID = t.GoodsSortId,
                    GoodsSortName = t.GoodsSortName,
                   
                }).ToList()
            }).ToList();
            ViewData["ModifyDrplist"] = Common.DataHelper.ToJSON(ProductsSortList);
            return PartialView();
            // return PartialView("ProductsSortSetup");
        } 
        #endregion
       
    }
}
