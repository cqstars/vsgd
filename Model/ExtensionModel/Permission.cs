
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class Permission
    {
        #region 1.0 生成 很纯洁的 实体对象 +Ou_Permission ToPOCO()
        /// <summary>
        /// 生成 很纯洁的 实体对象
        /// </summary>
        /// <returns></returns>
        public Permission ToPOCO()
        {
            Permission poco = new Permission()
            {
                PermissionID= this.PermissionID,
                Parent = this.Parent,
                Name = this.Name,
                AreaName = this.AreaName,
                ControllerName = this.ControllerName,
                ActionName = this.ActionName,
                FormMethod = this.FormMethod,
                OperationType = this.OperationType,
                Ico = this.Ico,
               PerMissionOrder = this.PerMissionOrder,
                IsLink = this.IsLink,
                LinkUrl = this.LinkUrl,
                IsShow = this.IsShow,
                IsDel = this.IsDel,
                AddTime = this.AddTime
            };
            return poco;
        }
        #endregion

        //public TreeNode ToNode()
        //{
        //    TreeNode node = new TreeNode()
        //    {
        //        id = this.pid,
        //        text = this.pName,
        //        state = "open",
        //        Checked = false,
        //        attributes = null,
        //        children = new List<TreeNode>()
        //    };
        //    return node;
        //}

        //#region 2.0 将 权限集合 转成 树节点集合 +List<MODEL.EasyUIModel.TreeNode> ToTreeNodes(List<Ou_Permission> listPer)
        ///// <summary>
        ///// 将 权限集合 转成 树节点集合
        ///// </summary>
        ///// <param name="listPer"></param>
        ///// <returns></returns>
        //public static List<MODEL.EasyUIModel.TreeNode> ToTreeNodes(List<Ou_Permission> listPer)
        //{
        //    List<MODEL.EasyUIModel.TreeNode> listNodes = new List<EasyUIModel.TreeNode>();
        //    //生成 树节点时，根据 pid=0的根节点 来生成
        //    LoadTreeNode(listPer, listNodes, 0);
        //    return listNodes;
        //}
        //#endregion

        //public static void LoadTreeNode(List<Ou_Permission> listPer,List<TreeNode> listNodes,int pid)
        //{
        //    foreach (var permission in listPer)
        //    {
        //        if (permission.pParent == pid)
        //        {
        //            //将 权限转成 树节点
        //            TreeNode node = permission.ToNode();
        //            listNodes.Add(node);
        //            LoadTreeNode(listPer, node.children, node.id);
        //        }
        //    }
        //}
    }
}
