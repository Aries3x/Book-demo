using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace BLL {
    public class BookBLL : Base.BaseBLL {
        /// <summary>
        /// 查询全部书籍
        /// </summary>
        /// <returns></returns>
        public List<BookEntity> GetAllBook() {
            List<BookEntity> booklist = this.dal.TEntity<BookEntity>()
              .AsQueryable().ToList();
            return booklist;
        }
        /// <summary>
        /// 根据id查询书籍
        /// </summary>
        /// <param name="bookid">id</param>
        /// <returns></returns>
        public BookEntity GetBookByID(int bookid) {
            BookEntity bookEntity = this.dal.TEntity<BookEntity>()
                .GetById(bookid);
            return bookEntity;
        }

        public List<BookEntity> GetPage(int currentPage, int pageSize, ref int totalPage) {

            var page = this.dal.TEntity<BookEntity>().
                AsQueryable().
                OrderBy(it => it.Bookid).
                ToPageList(currentPage, pageSize, ref totalPage);
            return page;
        }

        public List<BookEntity> GetTablePage(int limit, int offset) {

            var top5 = this.dal.TEntity<BookEntity>()
                .AsQueryable().Skip(offset).Take(limit).ToList();

            return top5;

        }

        public int GetTotal() {

            int bookcount = this.dal.TEntity<BookEntity>()
                .AsQueryable().Where(book => book.Bookid > 10).Count();

            return bookcount;

        }
        /// <summary>
        /// 新增书籍
        /// </summary>
        /// <param name="bookEntity"></param>
        /// <returns></returns>
        public int InsertBook(BookEntity bookEntity) {
            var result = this.dal.TEntity<BookEntity>()
                .AsInsertable(bookEntity).ExecuteCommand();
            return result;
        }
        /// <summary>
        /// 修改书籍
        /// </summary>
        /// <param name="bookEntity"></param>
        /// <returns></returns>
        public int UpdateBook(BookEntity bookEntity) {
            var result = this.dal.TEntity<BookEntity>()
                .AsUpdateable(bookEntity).UpdateColumns(book => new { book.Name, book.Price,}).ExecuteCommand();
            return result;
        }
        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool DeleteBook(int bookid) {
            var result = dal.TEntity<BookEntity>()
                .DeleteById(bookid);
            return result;
        }

    }

}
