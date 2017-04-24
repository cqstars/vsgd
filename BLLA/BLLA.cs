 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLA
{
	public partial class DepartMent : BaseBLL<Model.DepartMent>,IBLL.IDepartMentBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IDepartMentDAL;
		}
    }
	public partial class Good : BaseBLL<Model.Good>,IBLL.IGoodBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IGoodDAL;
		}
    }
	public partial class GoodsSort : BaseBLL<Model.GoodsSort>,IBLL.IGoodsSortBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IGoodsSortDAL;
		}
    }
	public partial class Permission : BaseBLL<Model.Permission>,IBLL.IPermissionBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IPermissionDAL;
		}
    }
	public partial class ProductsSort : BaseBLL<Model.ProductsSort>,IBLL.IProductsSortBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IProductsSortDAL;
		}
    }
	public partial class Role : BaseBLL<Model.Role>,IBLL.IRoleBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IRoleDAL;
		}
    }
	public partial class RolePermission : BaseBLL<Model.RolePermission>,IBLL.IRolePermissionBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IRolePermissionDAL;
		}
    }
	public partial class sysdiagram : BaseBLL<Model.sysdiagram>,IBLL.IsysdiagramBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IsysdiagramDAL;
		}
    }
	public partial class UserDB : BaseBLL<Model.UserDB>,IBLL.IUserDBBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IUserDBDAL;
		}
    }
	public partial class UserRole : BaseBLL<Model.UserRole>,IBLL.IUserRoleBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IUserRoleDAL;
		}
    }
	public partial class VipUserPermission : BaseBLL<Model.VipUserPermission>,IBLL.IVipUserPermissionBLL
    {
		public override void SetDAL()
		{
			idal = DBSession.IVipUserPermissionDAL;
		}
    }
}