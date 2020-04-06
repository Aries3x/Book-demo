using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Entity;
using PYF_Library.Models;

namespace PYF_Library.Controllers {
    public class AccountController : Controller {
        public AccountBLL accountBll = null;

        public AccountController() {
            accountBll = new AccountBLL();
        }

        public IActionResult AccountLogin() {
            return View();
        }

        public JsonResult Login(string account, string password) {

            DataResult result = null;

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password)) {
                result = new DataResult("500", "账号密码不能为空");
                return Json(result);
            }

            AccountEntity accountEntity = this.accountBll.GetAccountNameAndPassowrd(account, password);

            if (accountEntity == null) {
                return Json(new DataResult("404", "该账号不存在"));
            }

            result = new DataResult("200", "登录成功");
            result.data = accountEntity;

            return Json(result);

        }
    }
}