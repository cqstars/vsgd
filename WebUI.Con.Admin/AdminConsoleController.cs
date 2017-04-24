using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebUI.Helper;
using System.Web;

namespace WebUI.Con.Admin
{
    public class AdminConsoleController : Controller
    {
        

        #region 0.0--ckfindrt上传图片
        [Common.Attributes.Skip]
        public ActionResult UpLoadGoodsPic()
        {


            return PartialView();
        }
        #endregion
        #region 1.0--自己开发一个上传文件的接受Action
        [Common.Attributes.Skip]
        public ActionResult upload()
        {
            //定义错误消息
            string msg = "";
            //接受上传文件
            HttpPostedFileBase hp = Request.Files["upImage"];
            if (hp == null)
            {
                msg = "请选择文件.";
            }
            //获取上传目录 转换为物理路径
            string uploadPath = Server.MapPath("~/images/Uploads/");
            //获取文件名
            string fileName = DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(hp.FileName);
            //获取文件大小
            long contentLength = hp.ContentLength;
            //文件不能大于1M
            if (contentLength > 1024 * 1024)
            {
                msg = "文件大小超过限制要求.";
            }
            if (!checkFileExtension(fileName))
            {
                msg = "文件为不可上传的类型.";
            }
            //保存文件的物理路径
            string saveFile = uploadPath + fileName;
            try
            {
                //保存文件
                hp.SaveAs(saveFile);
                msg = "images/Uploads/" + fileName;
            }
            catch
            {
                msg = "上传失败.";
            }
            return Json(msg);

        }
        /// <summary>
        /// 检查文件后缀名是否符合要求
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool checkFileExtension(string fileName)
        {
            //获取文件后缀
            string fileExtension = System.IO.Path.GetExtension(fileName);
            if (fileExtension != null)
                fileExtension = fileExtension.ToLower();
            else
                return false;

            if (fileExtension != ".jpg" && fileExtension != ".gif")
                return false;

            return true;
        }
        #endregion
        #region 2.0--把Model.ViewModel.DrplistProductsSort显示到下拉列表，同时是index页面
        public ActionResult Index()
        {

            var Drplist = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy(s => s.ProductsSortID > 0).Select(t => new Model.ViewModel.ProductsSort()
            {
                ProductsSortID = t.ProductsSortID,
                ProductsSortName = t.ProductsSortName,
                nodes = t.GoodsSorts.Select(s => new Model.ViewModel.GoodSort()
                {
                    GoodsSortID = s.GoodsSortId,
                    GoodsSortName = s.GoodsSortName
                }
                    ).ToList()

            }).ToList();
            ViewData["Drplist"] = Common.DataHelper.ToJSON(Drplist);
            return View();
        }
        #endregion
        #region 3.0--添加产品到产品表,用BootstrapValidot验证get提交数据
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        public ActionResult Add_Goods()
        {
            if (Request["GoodName"] != null && Request["GoodName"].ToString() != "")
            {
                Model.Good add_Good = new Model.Good();
                add_Good.GoodsName = Request["GoodName"].ToString();
                add_Good.GoodsPic = Request["xFilePath"].ToString();
                add_Good.ProductsSortID = Convert.ToInt32(Request["ProductsSort"]);
                add_Good.GoodsSortID = Convert.ToInt32(Request["GoodSort"]);
                add_Good.SalePrice = Convert.ToDecimal(Request["saleprice"]);
                add_Good.RentPrice = Convert.ToDecimal(Request["rentprice"]);
                add_Good.GoodsBrife = Request["GoodBrife"].ToString();
                int ok = OperateContext.Current.BLLSession.IGoodBLL.Add(add_Good);
                if (ok == 1)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("Error");
                }
            }

            else
            {
                return Content("Error");
            }

        }
        #endregion
        #region 4.0--返回需要修改的产品信息 ModifyGoodsList(int id)
        [Common.Attributes.Skip]
        public ActionResult ModifyGoodsList(int id)
        {

            var GoodsList = OperateContext.Current.BLLSession.IGoodBLL.GetListBy_NoTrack(s => s.GoodsID == id).Select(s => new Model.ViewModel.GoodsList()
            {
                GoodsID=s.GoodsID,
                GoodsName = s.GoodsName,
                GoodsPic = s.GoodsPic,
                ProductsSortID = s.ProductsSortID ?? 0,
                GoodsSortID = s.GoodsSortID ?? 0,
                RentPrice = (s.RentPrice ?? 0).ToString("#0.00"),
                SalePrice = (s.SalePrice ?? 0).ToString("#0.00"),
                GoodsBrife = s.GoodsBrife,
                Specifications=s.Specifications,
                Features=s.Features,
                Supplies=s.Supplies

            }).FirstOrDefault();

            var ProductsSortList = OperateContext.Current.BLLSession.IProductsSortBLL.GetListBy_NoTrack(s => s.ProductsSortID > 0).Select(s => new SelectListItem()
            {
                Text = s.ProductsSortName,
                Value = s.ProductsSortID.ToString()


            });
            ViewData["ProductsSortDrop"] = ProductsSortList;

            var GoodsSortDropList = OperateContext.Current.BLLSession.IGoodsSortBLL.GetListBy_NoTrack(s=>s.ProductsSortID==GoodsList.ProductsSortID).Select(s => new SelectListItem()
                       {
                           Text= s.GoodsSortName,
                           Value = s.GoodsSortId.ToString()


                       });
            ViewData["GoodsSortDrop"] = GoodsSortDropList;
            return PartialView(GoodsList);

            
        }
        #endregion
        #region 5.0--ModifyGoods对产品基本项目进行更改
        [Common.Attributes.Skip]
        public ActionResult ModifyGoods(Model.ViewModel.GoodsList g)
        {

            Model.Good modify_g = new Model.Good();
            modify_g.GoodsID = g.GoodsID;
            modify_g.GoodsName = g.GoodsName;
            modify_g.GoodsPic = g.GoodsPic;
            modify_g.GoodsBrife = g.GoodsBrife;
            modify_g.GoodsSortID = g.GoodsSortID;
            modify_g.ProductsSortID = g.ProductsSortID;
            modify_g.SalePrice = Convert.ToDecimal(g.SalePrice);
            modify_g.RentPrice =Convert.ToDecimal(g.RentPrice);
            int ok=OperateContext.Current.BLLSession.IGoodBLL.Modify(modify_g, new string[] { "GoodsName", "RentPrice", "SalePrice", "GoodsSortID", "ProductsSortID", "GoodsPic", "GoodsBrife" });
            if (ok == 1)
            { return Content("Ok modify!"); }
            else {
                return Content("Error modify!");
            }
            
        }
        #endregion
        #region 5.1--ModifyGoodsSpecifications修改产品特性
        [Common.Attributes.Skip]
        [ValidateInput(false)]
        public ActionResult ModifyGoodsSpecifications(Model.ViewModel.GoodsList g)
        {
            Model.Good modify_g = new Model.Good();
            modify_g.GoodsID = g.GoodsID;
            modify_g.Specifications = g.Specifications;
            int ok = OperateContext.Current.BLLSession.IGoodBLL.Modify(modify_g, new string[] { "Specifications" });
            if (ok == 1)
            { return Content("Ok modify Specifications!"); }
            else
            {
                return Content("Error modify Specifications!");
            }
            
        }
        #endregion
        #region 5.2--ModifyGoodsFeatures修改产品规格
        [Common.Attributes.Skip]
        [ValidateInput(false)]
        public ActionResult ModifyGoodsFeatures(Model.ViewModel.GoodsList g)
        {
            Model.Good modify_g = new Model.Good();
            modify_g.GoodsID = g.GoodsID;
            modify_g.Features= g.Features;
            int ok = OperateContext.Current.BLLSession.IGoodBLL.Modify(modify_g, new string[] { "Features" });
            if (ok == 1)
            { return Content("Ok modify Features!"); }
            else
            {
                return Content("Error modify Features!");
            }
            
        }
        #endregion

        #region 5.3--ModifyGoodsSupplies修改产品配件与耗材
        [Common.Attributes.Skip]
        [ValidateInput(false)]
        public ActionResult ModifyGoodsSupplies(Model.ViewModel.GoodsList g)
        {
            Model.Good modify_g = new Model.Good();
            modify_g.GoodsID = g.GoodsID;
            modify_g.Supplies= g.Supplies;
            int ok = OperateContext.Current.BLLSession.IGoodBLL.Modify(modify_g, new string[] { "Supplies" });
            if (ok == 1)
            { return Content("Ok modify Supplies!"); }
            else
            {
                return Content("Error modify Supplies!");
            }
            
        }
        #endregion

        #region 6.0--GoodsSortDrp产品耳机目录级联变化
        [Common.Attributes.Skip]
        public ActionResult GoodsSortDrp(string ProductsSortId)
        {

            int id= Convert.ToInt32(ProductsSortId);
            var GoodsSortDropList = OperateContext.Current.BLLSession.IGoodsSortBLL.GetListBy_NoTrack(s => s.ProductsSortID == id).Select(s => new SelectListItem()
            {
                Text = s.GoodsSortName,
                Value = s.GoodsSortId.ToString()


            });
           ViewData["GoodsSortDrop"] = GoodsSortDropList;
            return Json(GoodsSortDropList,JsonRequestBehavior.AllowGet);
        }
        #endregion
        
    }
}
