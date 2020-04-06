using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using PYF_Library.Models;

namespace PYF_Library.Controllers {
    public class HomeController : Controller {

        public BookBLL bookBll = null;

        public HomeController() {
            bookBll = new BookBLL();
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Table() {
            return View();
        }

        public JsonResult GetTablePage(int limit, int offset) {

            var pageresult = this.bookBll.GetTablePage(limit, offset);
            var booklist = this.bookBll.GetAllBook();

            int total = booklist.ToArray().Length;
            return Json(new { rows = pageresult, total });
        }

        public JsonResult GetPage(int currentPage, int pageSize, int limit) {
            var totalPage = 0;
            var pageresult = this.bookBll.GetPage(currentPage, limit, ref totalPage);

            int total = totalPage;

            return Json(new { rows = pageresult, total });
        }



        public JsonResult GetAllBook() {
            DataResult result = new DataResult();

            List<BookEntity> booklist = this.bookBll.GetAllBook();

            if (booklist.Count > 0) {
                result.code = "200";
                result.data = booklist;
            } else {
                return Json(new DataResult("10000", "没有数据"));
            }

            return Json(result);
        }

        public JsonResult GetBookByID(int bookid) {
            BookEntity bookEntity = this.bookBll.GetBookByID(bookid);

            if (bookEntity != null) {
                return Json(new DataResult("200", bookEntity));
            } else {
                return Json(new DataResult("10000", "请联系管理员"));
            }
        }


        public JsonResult InsertBook(BookEntity bookEntity) {
            DataResult result = null;

            if (string.IsNullOrEmpty(bookEntity.Name) && bookEntity.Price <= 0) {
                return Json(new DataResult("10000", "输入信息不正确"));
            }
            result = new DataResult();

            var insertResult = this.bookBll.InsertBook(bookEntity);
            if (insertResult < 0) {
                return Json(new DataResult("10001", "添加失败,请联系管理员"));
            } else {
                result.code = "200";
                result.errorMsg = "添加成功";

            }


            return Json(result);
        }

        public JsonResult UpdateBook(BookEntity bookEntity) {

            DataResult result = null;

            if (string.IsNullOrEmpty(bookEntity.Name) || double.IsNaN(bookEntity.Price)) {
                return Json(new DataResult("10000", "输入信息不正确"));
            }

            result = new DataResult();
            var updateResult = this.bookBll.UpdateBook(bookEntity);
            if (updateResult < 0) {
                return Json(new DataResult("10001", "修改失败,请联系管理员"));
            } else {
                result.code = "200";
                result.errorMsg = "修改成功";
            }

            return Json(result);

        }

        public JsonResult DeleteBook(int bookid) {

            DataResult result = null;

            var deleteResult = this.bookBll.DeleteBook(bookid);
            if (deleteResult) {
                result = new DataResult();
                result.code = "200";
                result.errorMsg = "删除成功";
            } else {
                return Json(new DataResult("10000", "删除失败,请联系管理员"));
            }

            return Json(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

