using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Authorize]
    public class TodoesController : Controller
    {
        // Context でＤＢの操作を行う
        private TodoesContext db = new TodoesContext();

        //
        // 【C#】C#でhttp通信を行う方法。〜 Post通信・Get通信 〜
        //
        // http通信とは簡単に言うと通信方法です。主にWebページを見る際に使用されている通信方法になります。
        // もう少し詳細に言うと
        // Webページとなるhtmlが保存されているWebサーバに自身のPCからアクセスする際に使用する通信規格になります
        // 
        // その通信方法にはざっくり分けると
        // Get（データをもらう）通信と
        // Post（データを送る）通信の二つがあります。
        //
        //                   ActionResultについて   
        // クラス名              ヘルパーメソッド  概要
        // ViewResult            View              アクションメソッドに対応したViewを出力
        // RedirectToRouteResult RedirectToAction  指定のアクションメソッドに処理を転送
        // ContentResult         Content           指定されたテキストを出力
        // FileContentResult     File              指定されたファイルを出力
        // JsonResult            Json              指定されたオブジェクトをJSON形式で出力
        // HttpNotFoundResult    HttpNotFound      ４０４ページを出力
        // HttpStatusCodeResult                    HTTPのステータスコードを返す
        // EmptyResult                             何も行わない

        //
        //  Create Read Update Delete (CRUD = クラッド)
        //
        //  インデックスメソッド（アクションメソッド）
        //  クライアントから要求されたURLを元に呼び出されるコントローラー


        // GET: Todoes
        public ActionResult Index()
        {
            // /Views/Todoes/Index.cshtml をクライアントに返す。
            return View(db.Todoes.ToList());
        }

        // GET: Todoes/Details/5
        // id を貰う
        public ActionResult Details(int? id) //ブル型（idが未設定の場合、nullが設定される）
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);　// dbの検索
            if (todo == null)
            {
                // 一致しない場合、４０４ページを出力
                return HttpNotFound();
            }
            return View(todo); // 一致すればデータをVIEWに設定して返す。
        }

        // GET: Todoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,summary,detail,limit,done")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                // 登録準備
                db.Todoes.Add(todo);
                // ＤＢへ登録
                db.SaveChanges();
                // Index のページを表示 
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,summary,detail,limit,done")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); //ディスポーザーは終了処理　保持してるコンテキストを開放する。
            }
            base.Dispose(disposing);
        }
    }
}
