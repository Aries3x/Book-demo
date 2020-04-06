using DAL;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Base
{
    /// <summary>
    /// 逻辑层基类
    /// </summary>
    public class BaseBLL {
        protected BaseDAL dal = null;

        public BaseBLL() {
            dal = new BaseDAL();
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <returns></returns>
        public List<T> Get<T>() where T : class, new() {
            try {
                var result = dal.TEntity<T>().GetList();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// 插入单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Create<T>(T entity) where T : class, new() {
            try {
                dal.TEntity<T>().AsInsertable(entity).ExecuteReturnEntity();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 插入多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void Create<T>(List<T> entities) where T : class, new() {
            try {
                dal.TEntity<T>().AsInsertable(entities).ExecuteCommand();
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// 更改单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class, new() {
            try {
                dal.TEntity<T>().Update(entity);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 更改多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void Update<T>(List<T> entities) where T : class, new() {
            try {
                dal.TEntity<T>().UpdateRange(entities);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 删除单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public void Delete<T>(int id) where T : class, new() {
            try {
                dal.TEntity<T>().DeleteById(id);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 删除多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        public void Delete<T>(dynamic[] ids) where T : class, new() {
            try {
                dal.TEntity<T>().DeleteByIds(ids);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
