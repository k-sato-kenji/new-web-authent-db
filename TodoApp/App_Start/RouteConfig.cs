using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TodoApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ルーティングの定義
            // MAP ルートメソッドのURL 引数がルーティングの定義
            // リクエスト情報が
            // http://localhost:8080/todoes/Details/3　　←例
            // {controller} = todoesController
            // {action}     = Details
            // {id}         = 3
            // {controller} {action} が省略された場合、Indexメソッドとして処理される。  

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Todoes", action = "Index", id = UrlParameter.Optional } // デフォルトページ設定
            );
        }
    }
}
