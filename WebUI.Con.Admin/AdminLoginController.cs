using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebUI.Helper;
using System.Web;

namespace WebUI.Con.Admin
{
    public class AdminLoginController : Controller
    {
        #region 管理员登录密码
        /// <summary>
        /// 管理员登录密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Common.Attributes.Skip]
        public ActionResult Login()
        {
            return View();
        } 
        #endregion
        #region 1.0 管理员登陆页面 +ActionResult Login()
        /// <summary>
        /// 1.0 管理员登陆页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Common.Attributes.Skip]
        [Common.Attributes.AjaxRequest]
        public ActionResult Login(Model.ViewModel.LoginUser usrInfo)
        {
            
            //1.2服务器端验证，如果没有验证通过
            if (!ModelState.IsValid)
            {
                return OperateContext.Current.RedirectAjax("err", "没有权限!", null, "");
            }
            if (OperateContext.Current.LoginAdmin(usrInfo))
            {
                return OperateContext.Current.RedirectAjax("ok", "登陆成功~", null, "/admin/adminlogin/index");
            }
            else
            {
                return OperateContext.Current.RedirectAjax("err", "失败~~!", null, "");
            }
        }
        #endregion
        [Common.Attributes.Skip]
        public ActionResult Index()
        {
            return View();
        }
        #region 用户过期
        /// <summary>
        /// 用户过期
        /// </summary>
        /// <returns></returns>
        
        [Common.Attributes.Skip]

        public ActionResult UserErase()
        {
            OperateContext.Current.Usr = null;
            return PartialView("UserInfo");
        }  
        #endregion
    }
}
