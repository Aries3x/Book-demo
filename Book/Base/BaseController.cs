using Book.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;


namespace Book.Base
{
    /// <summary>
    /// 基础控制器：所有基类
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseController()
        {

        }

        /// <summary>
        /// 返回当前登录用户
        /// </summary>
        /// <returns></returns>
        public AccountEntity ThisAdmin()
        {
            AccountEntity adminEntity = HttpContext.Session.Get<AccountEntity>("account");

            if (adminEntity == null)
            {
                HttpContext.Session.Clear();
                JumpLogin();
            }

            return adminEntity;
        }

        public IActionResult JumpLogin()
        {
            return View("/Account/AccountLogin");
        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            bool isLogin = false;

            if (ThisAdmin() != null)
            {
                isLogin = true;
            }

            return isLogin;
        }
    }
}