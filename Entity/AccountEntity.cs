using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Entity {
    /// <summary>
    /// 用户实体类
    /// </summary>
    [SugarTable("T_Account")]
    public class AccountEntity {
        /// <summary>
        /// 构造方法
        /// </summary>
        public AccountEntity() {

        }

        /// <summary>
        /// 用户主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Userid { get; set; }

        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string Account { get; set; }

        [SugarColumn(IsIgnore = true)]
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 用户修改时间
        /// </summary>

        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime ModifyDate { get; set; }


    }
}
