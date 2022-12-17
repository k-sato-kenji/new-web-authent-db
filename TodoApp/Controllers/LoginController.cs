using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    // 認証なしの設定
    [AllowAnonymous]
    public class LoginController : Controller
    {

        //  login の実装
        // 内容を保持
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // その通信方法にはざっくり分けると
        // Get（データをもらう）通信と
        // Post（データを送る）通信の二つがあります。

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "UserName,Password")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    // 認証を保持（クッキー）
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Todoes");
                }
            }

            ViewBag.Message = "ログインに失敗しました。";
            return View(model);

        }

        //  logout の実装

        public ActionResult SignOut()
        {
            // 認証クッキーを削除される。
            FormsAuthentication.SignOut();
            //インデックス画面に戻す
            return RedirectToAction("Index");
        }

    }
}