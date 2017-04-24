
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;

namespace DALSQL
{
	public partial class DBSession:IDAL.IDBSession
    {
		#region 01 数据接口 IDepartMentDAL
		IDepartMentDAL iDepartMentDAL;
		public IDepartMentDAL IDepartMentDAL
		{
			get
			{
				if(iDepartMentDAL==null)
					iDepartMentDAL= new DepartMentDAL();
				return iDepartMentDAL;
			}
			set
			{
				iDepartMentDAL= value;
			}
		}
		#endregion

		#region 02 数据接口 IGoodDAL
		IGoodDAL iGoodDAL;
		public IGoodDAL IGoodDAL
		{
			get
			{
				if(iGoodDAL==null)
					iGoodDAL= new GoodDAL();
				return iGoodDAL;
			}
			set
			{
				iGoodDAL= value;
			}
		}
		#endregion

		#region 03 数据接口 IGoodsSortDAL
		IGoodsSortDAL iGoodsSortDAL;
		public IGoodsSortDAL IGoodsSortDAL
		{
			get
			{
				if(iGoodsSortDAL==null)
					iGoodsSortDAL= new GoodsSortDAL();
				return iGoodsSortDAL;
			}
			set
			{
				iGoodsSortDAL= value;
			}
		}
		#endregion

		#region 04 数据接口 IPermissionDAL
		IPermissionDAL iPermissionDAL;
		public IPermissionDAL IPermissionDAL
		{
			get
			{
				if(iPermissionDAL==null)
					iPermissionDAL= new PermissionDAL();
				return iPermissionDAL;
			}
			set
			{
				iPermissionDAL= value;
			}
		}
		#endregion

		#region 05 数据接口 IProductsSortDAL
		IProductsSortDAL iProductsSortDAL;
		public IProductsSortDAL IProductsSortDAL
		{
			get
			{
				if(iProductsSortDAL==null)
					iProductsSortDAL= new ProductsSortDAL();
				return iProductsSortDAL;
			}
			set
			{
				iProductsSortDAL= value;
			}
		}
		#endregion

		#region 06 数据接口 IRoleDAL
		IRoleDAL iRoleDAL;
		public IRoleDAL IRoleDAL
		{
			get
			{
				if(iRoleDAL==null)
					iRoleDAL= new RoleDAL();
				return iRoleDAL;
			}
			set
			{
				iRoleDAL= value;
			}
		}
		#endregion

		#region 07 数据接口 IRolePermissionDAL
		IRolePermissionDAL iRolePermissionDAL;
		public IRolePermissionDAL IRolePermissionDAL
		{
			get
			{
				if(iRolePermissionDAL==null)
					iRolePermissionDAL= new RolePermissionDAL();
				return iRolePermissionDAL;
			}
			set
			{
				iRolePermissionDAL= value;
			}
		}
		#endregion

		#region 08 数据接口 IsysdiagramDAL
		IsysdiagramDAL isysdiagramDAL;
		public IsysdiagramDAL IsysdiagramDAL
		{
			get
			{
				if(isysdiagramDAL==null)
					isysdiagramDAL= new sysdiagramDAL();
				return isysdiagramDAL;
			}
			set
			{
				isysdiagramDAL= value;
			}
		}
		#endregion

		#region 09 数据接口 IUserDBDAL
		IUserDBDAL iUserDBDAL;
		public IUserDBDAL IUserDBDAL
		{
			get
			{
				if(iUserDBDAL==null)
					iUserDBDAL= new UserDBDAL();
				return iUserDBDAL;
			}
			set
			{
				iUserDBDAL= value;
			}
		}
		#endregion

		#region 10 数据接口 IUserRoleDAL
		IUserRoleDAL iUserRoleDAL;
		public IUserRoleDAL IUserRoleDAL
		{
			get
			{
				if(iUserRoleDAL==null)
					iUserRoleDAL= new UserRoleDAL();
				return iUserRoleDAL;
			}
			set
			{
				iUserRoleDAL= value;
			}
		}
		#endregion

		#region 11 数据接口 IVipUserPermissionDAL
		IVipUserPermissionDAL iVipUserPermissionDAL;
		public IVipUserPermissionDAL IVipUserPermissionDAL
		{
			get
			{
				if(iVipUserPermissionDAL==null)
					iVipUserPermissionDAL= new VipUserPermissionDAL();
				return iVipUserPermissionDAL;
			}
			set
			{
				iVipUserPermissionDAL= value;
			}
		}
		#endregion

    }

}