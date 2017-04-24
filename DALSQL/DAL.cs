 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;

namespace DALSQL
{
	public partial class DepartMentDAL : BaseDAL<Model.DepartMent>,IDAL.IDepartMentDAL
    {
    }
	public partial class GoodDAL : BaseDAL<Model.Good>,IDAL.IGoodDAL
    {
    }
	public partial class GoodsSortDAL : BaseDAL<Model.GoodsSort>,IDAL.IGoodsSortDAL
    {
    }
	public partial class PermissionDAL : BaseDAL<Model.Permission>,IDAL.IPermissionDAL
    {
    }
	public partial class ProductsSortDAL : BaseDAL<Model.ProductsSort>,IDAL.IProductsSortDAL
    {
    }
	public partial class RoleDAL : BaseDAL<Model.Role>,IDAL.IRoleDAL
    {
    }
	public partial class RolePermissionDAL : BaseDAL<Model.RolePermission>,IDAL.IRolePermissionDAL
    {
    }
	public partial class sysdiagramDAL : BaseDAL<Model.sysdiagram>,IDAL.IsysdiagramDAL
    {
    }
	public partial class UserDBDAL : BaseDAL<Model.UserDB>,IDAL.IUserDBDAL
    {
    }
	public partial class UserRoleDAL : BaseDAL<Model.UserRole>,IDAL.IUserRoleDAL
    {
    }
	public partial class VipUserPermissionDAL : BaseDAL<Model.VipUserPermission>,IDAL.IVipUserPermissionDAL
    {
    }
}