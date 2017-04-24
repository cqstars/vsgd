
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
	public partial interface IBLLSession
    {
		IDepartMentBLL IDepartMentBLL{get;set;}
		IGoodBLL IGoodBLL{get;set;}
		IGoodsSortBLL IGoodsSortBLL{get;set;}
		IPermissionBLL IPermissionBLL{get;set;}
		IProductsSortBLL IProductsSortBLL{get;set;}
		IRoleBLL IRoleBLL{get;set;}
		IRolePermissionBLL IRolePermissionBLL{get;set;}
		IsysdiagramBLL IsysdiagramBLL{get;set;}
		IUserDBBLL IUserDBBLL{get;set;}
		IUserRoleBLL IUserRoleBLL{get;set;}
		IVipUserPermissionBLL IVipUserPermissionBLL{get;set;}
    }

}