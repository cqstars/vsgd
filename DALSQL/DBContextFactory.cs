using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
namespace DALSQL
{
    public class DBContextFactory:IDAL.IDBContextFactory
    {

        public System.Data.Entity.DbContext GetDbContext()
        {
             /// <summary>
        /// 创建 EF上下文 对象，在线程中共享 一个 上下文对象
        /// </summary>
        /// <returns></returns>
      
            //从当前线程中 获取 EF上下文对象
            DbContext dbContext = CallContext.GetData(typeof(DBContextFactory).Name) as DbContext;
            if (dbContext == null)
            {
                dbContext = new Model.cqstarsEntities();
                CallContext.SetData(typeof(DBContextFactory).Name, dbContext);
            }
            return dbContext;
        }
      
    }
}
