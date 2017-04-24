using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLA
{
    public partial class UserDB : BaseBLL<Model.UserDB>, IBLL.IUserDBBLL
    {

        public Model.UserDB Login(string strName, string strPwd)
        {
            Model.UserDB usr = base.GetListBy(s => s.UserName == strName).Select(u=>u.ToPOCO()).First();//这个user调用UserDB中poco方法，拿到精简的user给予登录Session

            //2.判断是否登陆成功
            //Md5    if (usr != null && usr.PassWord == Common.DataHelper.MD5(strPwd))
            if (usr != null && usr.PassWord == strPwd)
            {
                return usr;
            }

            return null;
        }
    }
}
