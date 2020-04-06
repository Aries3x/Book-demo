using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbContext<T> : SimpleClient<T> where T : class, new()
    {
        public DbContext(SqlSugarClient context) : base(context)
        {

        }
    }
}
