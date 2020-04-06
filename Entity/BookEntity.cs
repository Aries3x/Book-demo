using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Entity {
    /// <summary>
    /// 书籍实体类
    /// </summary>
    [SugarTable("T_Book")]
    public class BookEntity {
        /// <summary>
        /// 构造方法
        /// </summary>
        public BookEntity() { }

        /// <summary>
        /// 书籍主键
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Bookid { get; set; }

        /// <summary>
        /// 书籍名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public int Userid { get; set; }

        /// <summary>
        /// 书籍创建时间
        /// </summary>  
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 书籍修改时间
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime ModifyDate { get; set; }

    }
}
