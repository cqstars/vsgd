
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
	public partial interface IDBSession
    {
		IDepartMentDAL IDepartMentDAL{get;set;}
		IGoodDAL IGoodDAL{get;set;}
		IGoodsSortDAL IGoodsSortDAL{get;set;}
		IPermissionDAL IPermissionDAL{get;set;}
		IProductsSortDAL IProductsSortDAL{get;set;}
		IRoleDAL IRoleDAL{get;set;}
		IRolePermissionDAL IRolePermissionDAL{get;set;}
		IsysdiagramDAL IsysdiagramDAL{get;set;}
		IUserDBDAL IUserDBDAL{get;set;}
		IUserRoleDAL IUserRoleDAL{get;set;}
		IVipUserPermissionDAL IVipUserPermissionDAL{get;set;}
    }

}