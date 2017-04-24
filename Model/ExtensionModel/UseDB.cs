using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 扩展 用户 实体类
    /// </summary>
    public partial class UserDB
    {

        /// <summary>
        /// 生成 很纯洁的 实体对象
        /// </summary>
        /// <returns></returns>
        public UserDB ToPOCO()
        {
            UserDB poco = new UserDB()
            {

                UserID = this.UserID,
                UserName = this.UserName,
                PassWord = this.PassWord,
                Sex = this.Sex,
                NickName=this.NickName
                //= this.,
                // uDepId = this.uDepId,
                // uLoginName = this.uLoginName,
                // uPwd = this.uPwd,
                // uGender = this.uGender,
                // uPost = this.uPost,
                // uRemark = this.uRemark,
                // uIsDel = this.uIsDel,
                // uAddTime = this.uAddTime
            };
            return poco;
        }
    }
}
