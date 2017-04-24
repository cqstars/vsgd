
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;

namespace BLLA
{
	public partial class BLLSession:IBLL.IBLLSession
    {
		#region 01 业务接口 IDepartMentDAL
		IDepartMentBLL iDepartMentBLL;
		public IDepartMentBLL IDepartMentBLL
		{
			get
			{
				if(iDepartMentBLL==null)
					iDepartMentBLL= new DepartMent();
				return iDepartMentBLL;
			}
			set
			{
				iDepartMentBLL= value;
			}
		}
		#endregion

		#region 02 业务接口 IGoodDAL
		IGoodBLL iGoodBLL;
		public IGoodBLL IGoodBLL
		{
			get
			{
				if(iGoodBLL==null)
					iGoodBLL= new Good();
				return iGoodBLL;
			}
			set
			{
				iGoodBLL= value;
			}
		}
		#endregion

		#region 03 业务接口 IGoodsSortDAL
		IGoodsSortBLL iGoodsSortBLL;
		public IGoodsSortBLL IGoodsSortBLL
		{
			get
			{
				if(iGoodsSortBLL==null)
					iGoodsSortBLL= new GoodsSort();
				return iGoodsSortBLL;
			}
			set
			{
				iGoodsSortBLL= value;
			}
		}
		#endregion

		#region 04 业务接口 IPermissionDAL
		IPermissionBLL iPermissionBLL;
		public IPermissionBLL IPermissionBLL
		{
			get
			{
				if(iPermissionBLL==null)
					iPermissionBLL= new Permission();
				return iPermissionBLL;
			}
			set
			{
				iPermissionBLL= value;
			}
		}
		#endregion

		#region 05 业务接口 IProductsSortDAL
		IProductsSortBLL iProductsSortBLL;
		public IProductsSortBLL IProductsSortBLL
		{
			get
			{
				if(iProductsSortBLL==null)
					iProductsSortBLL= new ProductsSort();
				return iProductsSortBLL;
			}
			set
			{
				iProductsSortBLL= value;
			}
		}
		#endregion

		#region 06 业务接口 IRoleDAL
		IRoleBLL iRoleBLL;
		public IRoleBLL IRoleBLL
		{
			get
			{
				if(iRoleBLL==null)
					iRoleBLL= new Role();
				return iRoleBLL;
			}
			set
			{
				iRoleBLL= value;
			}
		}
		#endregion

		#region 07 业务接口 IRolePermissionDAL
		IRolePermissionBLL iRolePermissionBLL;
		public IRolePermissionBLL IRolePermissionBLL
		{
			get
			{
				if(iRolePermissionBLL==null)
					iRolePermissionBLL= new RolePermission();
				return iRolePermissionBLL;
			}
			set
			{
				iRolePermissionBLL= value;
			}
		}
		#endregion

		#region 08 业务接口 IsysdiagramDAL
		IsysdiagramBLL isysdiagramBLL;
		public IsysdiagramBLL IsysdiagramBLL
		{
			get
			{
				if(isysdiagramBLL==null)
					isysdiagramBLL= new sysdiagram();
				return isysdiagramBLL;
			}
			set
			{
				isysdiagramBLL= value;
			}
		}
		#endregion

		#region 09 业务接口 IUserDBDAL
		IUserDBBLL iUserDBBLL;
		public IUserDBBLL IUserDBBLL
		{
			get
			{
				if(iUserDBBLL==null)
					iUserDBBLL= new UserDB();
				return iUserDBBLL;
			}
			set
			{
				iUserDBBLL= value;
			}
		}
		#endregion

		#region 10 业务接口 IUserRoleDAL
		IUserRoleBLL iUserRoleBLL;
		public IUserRoleBLL IUserRoleBLL
		{
			get
			{
				if(iUserRoleBLL==null)
					iUserRoleBLL= new UserRole();
				return iUserRoleBLL;
			}
			set
			{
				iUserRoleBLL= value;
			}
		}
		#endregion

		#region 11 业务接口 IVipUserPermissionDAL
		IVipUserPermissionBLL iVipUserPermissionBLL;
		public IVipUserPermissionBLL IVipUserPermissionBLL
		{
			get
			{
				if(iVipUserPermissionBLL==null)
					iVipUserPermissionBLL= new VipUserPermission();
				return iVipUserPermissionBLL;
			}
			set
			{
				iVipUserPermissionBLL= value;
			}
		}
		#endregion

    }

}