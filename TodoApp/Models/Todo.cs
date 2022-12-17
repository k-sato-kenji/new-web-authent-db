using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Todo  // ＤＢレイアウトの元になる、作成時は複数形になる。
    {
        // ディスプレイNAME アノテーションを設定する。
        // ヘッダー部が日本語になる。
        // これがないと、プロパティー名がヘッダーに表示される。
 
        public int id { get; set; }  // 自動的に主キーになる。

        // 必須
        [Required]
        [DisplayName("概要")]
        public string summary { get; set; }

        // 必須
        [Required]
        [DisplayName("詳細")]
        public string detail { get; set; }

        // 必須
        [Required]
        [DisplayName("期限")]
        public DateTime limit { get; set; }

        [DisplayName("完了！")]
        public bool done { get; set; }

    }
}