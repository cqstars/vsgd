using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;


namespace WebUI.Helper
{
    /// <summary>
    /// 操作上下文
    /// </summary>
    public class OperateContext
    {
        const string Admin_CookiePath = "/admin/";
        const string Admin_InfoKey = "ainfo";
        const string Admin_PermissionKey = "apermission";
        const string Admin_TreeString = "aTreeString";
        const string Admin_LogicSessionKey = "BLLSession";
        

        #region 0.1 Http上下文 及 相关属性
        /// <summary>
        /// Http上下文
        /// </summary>
        HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        HttpResponse Response
        {
            get
            {
                return ContextHttp.Response;
            }
        }

        HttpRequest Request
        {
            get
            {
                return ContextHttp.Request;
            }
        }

        System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return ContextHttp.Session;
            }
        }
        #endregion
        #region 0.3 业务仓储 +IBLL.IBLLSession BLLSession
        /// <summary>
        /// 业务仓储
        /// </summary>
        public IBLL.IBLLSession BLLSession;
        #endregion
        #region 0.2 当前用户对象 +Model.UseDB Usr
        // <summary>
        /// 当前用户对象
        /// </summary>
        public Model.UserDB Usr
        {
            get
            {
                return Session[Admin_InfoKey] as Model.UserDB;
            }
            set
            {
                Session[Admin_InfoKey] = value;
            }
        }
        #endregion
        #region 0.2_2 上下文用户权限
        /// <summary>
        /// 上下文中用户权限
        /// </summary>
        public List<Model.Permission> UsrPermission
        {
            get
            {
                return Session[Admin_PermissionKey] as List<Model.Permission>;
            }
            set
            {
                Session[Admin_PermissionKey] = value;
            }
        }
        #endregion
        

        #region 0.2实例构造函数 初始化 业务仓储
        public OperateContext()
        {
            BLLSession = DI.SpringHelper.GetObject<IBLL.IBLLSession>("BLLSession");
        }
        #endregion
        #region 1.0 获取当前 操作上下文 + OperateContext Current
        /// <summary>
        /// 获取当前 操作上下文 (为每个处理浏览器请求的服务器线程 单独创建 操作上下文)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                OperateContext oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }
        #endregion

        //---------------------------------------------2.0 登陆权限 等系统操作--------------------
        #region 2.0 根据用户id查询用户权限 +List<Model.UserDB> GetUserPermission(int usrId)
        /// <summary>
        //根据用户id查询用户权限
        //</summary>
        /// <summary>
        //<param name="usrId"></param>
        /// <returns></returns>

        public List<Model.Permission> GetUserPermission(int usrId)
        {

            //-------A.根据用户角色查询
            //1.0 根据用户 id 查到 该用户的 角色id
            List<int?> listRoleId = Current.BLLSession.IUserRoleBLL.GetListBy(ur => ur.UserID == usrId).Select(ur => ur.RoleID).ToList();
            //2.0 根据角色 id 查询角色权限 id
            List<int?> listPerIds = Current.BLLSession.IRolePermissionBLL.GetListBy(rp => listRoleId.Contains(rp.RoleID)).Select(rp => rp.PermissionID).ToList();
            //3.0 查询所有角色数据
            List<Model.Permission> listPermission = Current.BLLSession.IPermissionBLL.GetListBy(p => listPerIds.Contains(p.PermissionID)).Select(p => p.ToPOCO()).ToList();
            //-------B.根据用户特权查询
            //b.1 查询 用户特权id
            List<int?> vipPerIds = Current.BLLSession.IVipUserPermissionBLL.GetListBy(vip => vip.VipID == usrId).Select(vip => vip.VipPerMissionID).ToList();
            //b.2 查询 特权数据
            List<Model.Permission> listPermission2 = Current.BLLSession.IPermissionBLL.GetListBy(p => vipPerIds.Contains(p.PermissionID)).Select(p => p.ToPOCO()).ToList();
            //-------C.将两个权限集合 合并（将集合2的权限数据 添加到 集合1中）
            listPermission2.ForEach(p =>
            {
                listPermission.Add(p);
            });
            return listPermission.OrderBy(u => u.PerMissionOrder).ToList();
        }
        #endregion
        #region 2.1 管理员登录方法 + bool LoginAdmin(Model.ViewModel.LoginUser usrPara)
        /// <summary>
        /// 管理员登录方法
        /// </summary>
        /// <param name="usrPara"></param>
        public bool LoginAdmin(Model.ViewModel.LoginUser usrPara)
        {
            
            //到业务成查询
            Model.UserDB usr = BLLSession.IUserDBBLL.Login(usrPara.LoginName, usrPara.Pwd);
            if (usr != null)
            {
                
                //2.1 保存 用户数据(Session or Cookie)
                Usr = usr;
                //如果选择了复选框，则要使用cookie保存数据
                if (usrPara.IsAlways)
                {
                    //2.1.2将用户id加密成字符串
                    string strCookieValue = Common.SecurityHelper.EncryptUserDB(usr.UserID.ToString());
                    //2.1.3创建cookie
                    HttpCookie cookie = new HttpCookie(Admin_InfoKey, strCookieValue);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie.Path = Admin_CookiePath;
                    Response.Cookies.Add(cookie);
                }
                //2.2 查询当前用户的 权限，并将权限 存入 Session 中
                UsrPermission = GetUserPermission(usr.UserID);
                return true;
            }
            return false;
        }
        #endregion
        #region  2.2 判断当前用户 是否有 访问当前页面的权限 +bool HasPemission
        /// <summary>
        /// 2.3 判断当前用户 是否有 访问当前页面的权限
        /// </summary>
        /// <param name="areaName">区域名</param>
        /// <param name="controllerName">控制器名</param>
        /// <param name="actionName">方法名</param>
        /// <param name="httpMethod">方法属性</param>
        /// <returns></returns>
        public bool HasPemission(string areaName, string controllerName, string actionName, string httpMethod)
        {
            //var listP = from per in UsrPermission
            //            where string.Equals(per.AreaName, areaName, StringComparison.CurrentCultureIgnoreCase) &&
            //                string.Equals(per.ControllerName, controllerName, StringComparison.CurrentCultureIgnoreCase) &&
            //                string.Equals(per.ActionName, actionName, StringComparison.CurrentCultureIgnoreCase) &&
            //                (per.FormMethod ?? 0) == (httpMethod.ToLower() == "get" ? 1 : 2)
            //            select per;
            var listP = from per in UsrPermission
                        where string.Equals(per.AreaName, areaName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.ControllerName, controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.ActionName, actionName, StringComparison.CurrentCultureIgnoreCase)
                        select per;
            return listP.Count() > 0;
        }
        #endregion
        #region 2.3 判断当前用户是否登陆 +bool IsLogin()
        /// <summary>
        /// 判断当前用户是否登陆 而且
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            //1.验证用户是否登陆(Session && Cookie)
            if (Session[Admin_InfoKey] == null)
            {
                if (Request.Cookies[Admin_InfoKey] == null)
                {
                    //重新登陆，内部已经调用了 Response.End(),后面的代码都不执行了！ (注意：如果Ajax请求，此处不合适！)
                    //filterContext.HttpContext.Response.Redirect("/admin/admin/login");
                    return false;
                }
                else//如果有cookie则从cookie中获取用户id并查询相关数据存入 Session
                {
                    string strUserInfo = Request.Cookies[Admin_InfoKey].Value;
                    strUserInfo = Common.SecurityHelper.DecryptUserDB(strUserInfo);
                    int userId = int.Parse(strUserInfo);
                    Model.UserDB usr = BLLSession.IUserDBBLL.GetListBy(u => u.UserID == userId).First();
                    Usr = usr;
                    UsrPermission = OperateContext.Current.GetUserPermission(usr.UserID);
                }
            }
            return true;
        }
        #endregion

        //---------------------------------------------3.0 公用操作方法--------------------

        #region 3.1 生成 Json 格式的返回值 +ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        /// <summary>
        /// 生成 Json 格式的返回值
        /// </summary>
        /// <param name="statu"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="backurl"></param>
        /// <returns></returns>
        public ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        {
            Model.FormatModel.AjaxMsgModel ajax = new Model.FormatModel.AjaxMsgModel()
            {
                Statu = statu,
                Msg = msg,
                Data = data,
                BackUrl = backurl
            };
            JsonResult res = new JsonResult();
            res.Data = ajax;
            return res;
        }
        #endregion

        #region 3.2 重定向方法 根据Action方法特性  +ActionResult Redirect(string url, ActionDescriptor action)
        /// <summary>
        /// 重定向方法 有两种情况：如果是Ajax请求，则返回 Json字符串；如果是普通请求，则 返回重定向命令
        /// </summary>
        /// <returns></returns>
        public ActionResult Redirect(string url, ActionDescriptor action)
        {
            //如果Ajax请求没有权限，就返回 Json消息
            if (action.IsDefined(typeof(Common.Attributes.AjaxRequestAttribute), false)
            || action.ControllerDescriptor.IsDefined(typeof(Common.Attributes.AjaxRequestAttribute), false))
            {
                
                return RedirectAjax("nologin", "您没有登陆或没有权限访问此页面~~", null, url);
            }
            else//如果 超链接或表单 没有权限访问，则返回 302重定向命令
            {
                return new RedirectResult(url);
            }
        }
        #endregion

        //public static List<MODEL.EasyUIModel.TreeNode> CurUserPermission
        //{
        //    get
        //    {
        //        //3.1 从Session中获取权限
        //        List<MODEL.Ou_Permission> listPer = Context.Session["aPermission"] as List<MODEL.Ou_Permission>;
        //        //3.2 将 权限数据 转成 easyUi Tree的数据
        //        //MODEL.EasyUIModel.Tree treeObj = new MODEL.EasyUIModel.Tree()
        //        //{
        //        //    animate = true,
        //        //    checkbox = false,
        //        //    cascadeCheck = false,
        //        //    onlyLeafCheck = true,
        //        //    dnd = false,
        //        //    data = new List<MODEL.EasyUIModel.TreeNode>()
        //        //};
        //        ////3.3 遍历权限集合 生成 树节点集合
        //        //treeObj.data = MODEL.Ou_Permission.ToTreeNodes(listPer);

        //        return MODEL.Ou_Permission.ToTreeNodes(listPer);
        //    }
        //}
    }
}
