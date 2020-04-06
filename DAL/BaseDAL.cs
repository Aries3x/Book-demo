using BaseHelper.lang;
using SqlSugar;
using System;

namespace DAL {
    public class BaseDAL{
        /// <summary>
        /// 初始化SqlSugar
        /// </summary> 
       public SqlSugarClient sqlSugarDB;

            /// <summary>
            /// 构造方法
            /// </summary>
            public BaseDAL() {
                sqlSugarDB = new SqlSugarClient(
                    new ConnectionConfig() {
                        ConnectionString = DBConfig.ConnectionString,
                        DbType = DbType.SqlServer,
                        IsAutoCloseConnection = true
                    });
            }

            /// <summary>
            /// 数据实体上下文
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public DbContext<T> TEntity<T>() where T : class, new() => new DbContext<T>(sqlSugarDB);


            /// <summary>
            /// 开启事务
            /// </summary>
            public void BeginTran() {
                sqlSugarDB.BeginTran();
            }
            /// <summary>
            /// 提交事务
            /// </summary>
            public void CommitTran() {
                sqlSugarDB.CommitTran();
            }
            /// <summary>
            /// 回滚
            /// </summary>
            public void RollbackTran() {
                sqlSugarDB.RollbackTran();
            }

            /// <summary>
            /// 事务处理
            /// </summary>
            /// <param name="processAction">数据处理方法</param>
            /// <param name="failAction">失败方法</param>
            public void UseTran(Action processAction, Action<Exception> failAction = null) {
                try {
                    BeginTran();
                    if (processAction.IsNotNullOrEmpty()) {
                        processAction();
                    }
                    CommitTran();
                } catch (Exception ex) {
                    RollbackTran();
                    if (failAction.IsNotNullOrEmpty()) {
                        failAction(ex);
                    }
                }
            }

            /// <summary>
            /// 事务处理
            /// </summary>
            /// <typeparam name="T">返回类型</typeparam>
            /// <param name="processAction">数据处理方法</param>
            /// <param name="failAction">失败方法</param>
            /// <returns>返回结果</returns>
            public T UseTran<T>(Func<T> processAction, Action<Exception> failAction = null) {
                T value = default(T);
                try {
                    BeginTran();
                    if (processAction.IsNotNullOrEmpty()) {
                        value = processAction();
                    }
                    CommitTran();
                } catch (Exception ex) {
                    RollbackTran();
                    if (failAction.IsNotNullOrEmpty()) {
                        failAction(ex);
                    }
                }
                return value;
            }

        }
    }
