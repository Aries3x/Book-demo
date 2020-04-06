using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using BaseHelper;

namespace BLL {
    public  class AccountBLL :Base.BaseBLL{
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public AccountEntity GetAccountNameAndPassowrd(string account,string password) {
            //对用户的密码MD5加密
            password = DataEncrypt.DataMd5(password);
            AccountEntity accountEntity = dal.TEntity<AccountEntity>()
                .AsQueryable()
                .Where(a => a.Account == account && a.Password == password)
                .First();
            return accountEntity;
        }
    }
}
