using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace IDAL
{
    public interface IDBContextFactory
    {
        /// <summary>
        /// 获取 EF 上下文对象
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}
