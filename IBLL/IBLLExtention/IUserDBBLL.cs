using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
   public partial interface IUserDBBLL
    {
       Model.UserDB Login(string StrName, string strPwd);
    }
}
